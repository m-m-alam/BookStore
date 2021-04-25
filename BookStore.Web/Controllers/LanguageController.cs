using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Web.Models;
using BookStore.Web.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Web.Controllers
{
    public class LanguageController : Controller
    {
        private readonly ILanguageRepository _repository;
        public LanguageController(ILanguageRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            var data = _repository.GetAllLanguages();
            return View(data);
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(LanguageModel model)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
    }
}
