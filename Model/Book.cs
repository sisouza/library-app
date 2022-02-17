

using System.ComponentModel.DataAnnotations;

namespace library_app.Models
{
    public class Book {
        [Required]
        public string Title {get; set;}
        [Required]
        public string Author {get; set;}
        [Required]
        public int Year {get; set;}
        [Required]
        public string Genre {get; set;}
        

    }
}