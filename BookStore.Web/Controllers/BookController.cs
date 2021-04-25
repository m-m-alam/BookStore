using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Web.Models;
using BookStore.Web.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStore.Web.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly ILanguageRepository _languageRepository;
        private readonly IWebHostEnvironment _webHost;
        public BookController(IBookRepository bookRepository, 
            ILanguageRepository languageRepository,
            IWebHostEnvironment webHost)
        {
            _bookRepository = bookRepository;
            _languageRepository = languageRepository;
            _webHost = webHost;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddBook()
        {
            var allLanguage = _languageRepository.GetAllLanguages();
            ViewBag.language = new SelectList(allLanguage, "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult AddBook(BookModel model)
        {
            if (ModelState.IsValid)
            {
                if(model.Image != null)
                {
                    string folder = "Upload/Image/Book";
                    folder += Guid.NewGuid().ToString()+model.Image.FileName;
                    string serverFolder = Path.Combine(_webHost.WebRootPath, folder);

                    model.Image.CopyTo(new FileStream(serverFolder, FileMode.Create));
                    model.ImageUrl = "/"+folder;
                }
                
                _bookRepository.AddBook(model);
                return RedirectToAction(nameof(GetAllBooks));
            }
            return View(model);
        }

        public IActionResult GetAllBooks()
        {
            var data = _bookRepository.GetAllBooks();
            return View(data);
        }
         public IActionResult GetBook(int id)
        {
            var data = _bookRepository.GetBookById(id);
            return View(data);
        }

        public List<BookModel> SearchBooks(string bookName, string authorName)
        {
            return _bookRepository.SearchBook(bookName, authorName);
        }

        public List<LanguageModel> GetLanguages()
        {
            return new List<LanguageModel>()
            {
                new LanguageModel() { Id = 1, Name = "English" },
                new LanguageModel() { Id = 1, Name = "Bangla" },
                new LanguageModel() { Id = 1, Name = "Hindi" },
            };
        }
    }
}
