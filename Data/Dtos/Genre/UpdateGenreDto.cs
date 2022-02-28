using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using library_app.Models;

namespace library_app.Data.Dtos
{
    public class UpdateGenreDto
    {
        [Required(ErrorMessage = "Name can not be empty")]
        public string Name { get; set; }
    }
}