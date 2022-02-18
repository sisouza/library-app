

using System.ComponentModel.DataAnnotations;

namespace library_app.Models
{
    public class Book
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Title can not be empty")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Author can not be empty")]
        public string Author { get; set; }
        [Required(ErrorMessage = "Year can not be empty")]
        public int Year { get; set; }
        [Required(ErrorMessage = " can not be empty")]
        public string Genre { get; set; }


    }
}