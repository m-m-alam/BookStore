using BookStore.Web.Models;
using System.Collections.Generic;

namespace BookStore.Web.Repository
{
    public interface ILanguageRepository
    {
        void Add(LanguageModel model);
        List<LanguageModel> GetAllLanguages();
    }
}