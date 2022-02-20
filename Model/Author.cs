using System.ComponentModel.DataAnnotations;

namespace library_app.Models
{
    public class Author
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name can not be empty")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Country can not be empty")]
        public string Country { get; set; }


    }
}