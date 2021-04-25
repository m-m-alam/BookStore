using BookStore.Web.Models;
using System.Collections.Generic;

namespace BookStore.Web.Repository
{
    public interface IBookRepository
    {
        void AddBook(BookModel model);
        List<BookModel> GetAllBooks();
        BookModel GetBookById(int id);
        List<BookModel> SearchBook(string title, string authorName);
    }
}