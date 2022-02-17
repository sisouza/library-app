
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
        public  IActionResult CreateBook([FromBody] Book book)
        {
            book.Id = id++;
            books.Add(book);
            return CreatedAtAction(nameof(getById), new {Id = book.Id}, book);

        }

        [HttpGet]
        public IActionResult getAll()
        {
            return Ok(books);
        }

        [HttpGet("{id}")]
        public IActionResult  getById(int id) {
             Book book = books.FirstOrDefault(book => book.Id == id);

            if(book != null){
                return Ok(book);
            }
            return NotFound();
        }
    }
}