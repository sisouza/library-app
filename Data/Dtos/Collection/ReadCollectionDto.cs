using library_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace library_app.Data.Dtos
{
    public class ReadCollectionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Book Book { get; set; }
        public Genre Genre { get; set; }
    }
}