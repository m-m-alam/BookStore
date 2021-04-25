using BookStore.Web.Data;
using BookStore.Web.Entity;
using BookStore.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Web.Repository
{
    public class LanguageRepository : ILanguageRepository
    {
        private readonly ApplicationDbContext _db;
        public LanguageRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public void Add(LanguageModel model)
        {
            var entity = new Language()
            {
                Name = model.Name
            };
            _db.Languages.Add(entity);
            _db.SaveChanges();
        }

        public List<LanguageModel> GetAllLanguages()
        {
            var allLanguages = _db.Languages.ToList();
            var data = new List<LanguageModel>();
            foreach (var singleLanguage in allLanguages)
            {
                var language = new LanguageModel()
                {
                    Id = singleLanguage.Id,
                    Name = singleLanguage.Name
                };
                data.Add(language);
            }
            return data;
        }
    }
}
