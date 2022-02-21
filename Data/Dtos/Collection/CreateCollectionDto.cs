using System;
using library_app.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace library_app.Data.Dtos
{
    public class CreateCollectionDto
    {
        public int BookId { get; set; }
        public int GenreId { get; set; }

    }
}