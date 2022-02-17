
using System.Collections.Generic;
using library_app.Models;
using Microsoft.AspNetCore.Mvc;

namespace library_app.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        
        //set book list using Book Model
        private static List<Book> books = new List<Book>();


        //create a new book
        public void CreateBook(Book book)
        {
            books.Add(book);
        }
    }
}