using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using library_app.Models;

namespace library_app.Models
{
    public class Collection
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name can not be empty")]
        public string Name { get; set; }

        public virtual Book Book { get; set; }
        public virtual Genre Genre { get; set; }

        public int BookId { get; set; }
        public int GenreId { get; set; }

    }
}