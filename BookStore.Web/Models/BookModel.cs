using BookStore.Web.Entity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Web.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        [Required (ErrorMessage ="Please enter your Title")]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public int LanguageId { get; set; }
        [Required]
        [Display(Name ="Total Page")]
        public int TotalPage { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public IFormFile Image { get; set; }
        public string Language { get; set; }
        public string ImageUrl { get; set; }
    }
}
