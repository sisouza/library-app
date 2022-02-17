
using System;
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
        [HttpPost]
        public void CreateBook([FromBody]Book book)
        {
            books.Add(book);
            Console.WriteLine(book.Title);
        }

        [HttpGet]
        public IEnumerable<Book> listBooks()
        {
            return books;
        }
    }
}