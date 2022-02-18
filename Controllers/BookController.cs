
using System;
using System.Collections.Generic;
using System.Linq;
using library_app.Data;
using library_app.Models;
using Microsoft.AspNetCore.Mvc;

namespace library_app.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {

        private BookDbContext _context;

        //set book list using Book Model
        private static List<Book> books = new List<Book>();
        //id
        private static int id = 1;


        //create a new book
        [HttpPost]
        public IActionResult CreateBook([FromBody] Book book)
        {

            _context.Books.Add(book);
            _context.SaveChanges();
            return CreatedAtAction(nameof(getById), new { Id = book.Id }, book);

        }

        [HttpGet]
        public IEnumerable<Book> getAll()
        {
            return _context.Books;
        }

        [HttpGet("{id}")]
        public IActionResult getById(int id)
        {
            Book book = _context.Books.FirstOrDefault(book => book.Id == id);

            if (book != null)
            {
                return Ok(book);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult updateBook(int id, [FromBody] Book newBook)
        {
            Book book = _context.Books.FirstOrDefault(book => book.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            book.Title = newBook.Title;
            book.Author = newBook.Author;
            book.Genre = newBook.Genre;
            book.Year = newBook.Year;

            _context.SaveChanges();
            return NoContent();

        }
    }
}