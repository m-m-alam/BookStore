using BookStore.Web.Data;
using BookStore.Web.Entity;
using BookStore.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Web.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _db;
        public BookRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public void AddBook(BookModel model)
        {
            var entity = new Book()
            {
                Title = model.Title,
                Author = model.Author,
                Description = model.Description,
                Category = model.Category,
                LanguageId = model.LanguageId,
                Image = model.ImageUrl,
                TotalPage = model.TotalPage,
                CreatedOn = DateTime.Now
            };
            _db.Books.Add(entity);
            _db.SaveChanges();
        }
        public List<BookModel> GetAllBooks()
        {
            var allBooks = _db.Books.ToList();
            var books = new List<BookModel>();
            foreach (var book in allBooks)
            {
                var data = new BookModel()
                {
                    Id = book.Id,
                    Title = book.Title,
                    Author = book.Author,
                    Description = book.Description,
                    Category = book.Category,
                    LanguageId = book.LanguageId,
                    TotalPage = book.TotalPage,
                    CreatedOn = book.CreatedOn,
                    UpdatedOn = book.UpdatedOn,
                    ImageUrl = book.Image
                };
                books.Add(data);
            }
            return books;
        }
        public BookModel GetBookById(int id)
        {
            var data = _db.Books.Where(x => x.Id == id).Select(
            book => new BookModel()
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Description = book.Description,
                Category = book.Category,
                LanguageId = book.LanguageId,
                Language = book.Language.Name,
                TotalPage = book.TotalPage,
                CreatedOn = book.CreatedOn,
                UpdatedOn = book.UpdatedOn
            }).FirstOrDefault();

            return data;
        }

        public List<BookModel> SearchBook(string title, string authorName)
        {
            var data = DataSource().Where(x => x.Title.Contains(title) || x.Author.Contains(authorName)).ToList();
            return data;
        }
        private List<BookModel> DataSource()
        {
            return null;
        }
    }
}
