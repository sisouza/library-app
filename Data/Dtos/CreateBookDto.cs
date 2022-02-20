using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using library_app.Models;

namespace library_app.Data.Dtos
{
    public class CreateBookDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Title can not be empty")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Author can not be empty")]
        public string Author { get; set; }
        [Required(ErrorMessage = "Genre can not be empty")]
        public string Genre { get; set; }
        [Required(ErrorMessage = "Year can not be empty")]
        public int Year { get; set; }
    }
}