using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using library_app.Models;

namespace library_app.Data.Dtos
{
    public class ReadAuthorDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "name can not be empty")]
        public string Name { get; set; }
        public object Books { get; set; }

    }
}