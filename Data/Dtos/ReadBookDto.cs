using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using library_app.Models;

namespace library_app.Data.Dtos
{
    public class ReadBookDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Title { get; set; }

        public Author Author { get; set; }

        public string Genre { get; set; }

        public int Year { get; set; }
    }
}