using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using library_app.Models;

namespace library_app.Models
{
    public class Genre
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name can not be empty")]
        public string Name { get; set; }

        [JsonIgnore]
        public virtual List<Collection> Collections { get; set; }




    }
}