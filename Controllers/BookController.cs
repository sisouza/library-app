
using System;
using System.Collections.Generic;
using System.Linq;
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
        //id
        private static int id = 1;


        //create a new book
        [HttpPost]
        public void CreateBook([FromBody] Book book)
        {
            book.Id = id++;
            books.Add(book);

        }

        [HttpGet]
        public IEnumerable<Book> getAll()
        {
            return books;
        }

        [HttpGet("{id}")]
        public Book getById(int id)
        {
            books.FirstOrDefault(book => book.Id == id);
        }
    }
}