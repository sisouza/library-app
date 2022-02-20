
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using library_app.Data;
using library_app.Data.Dtos;
using library_app.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace library_app.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private BookDbContext _context;
        private IMapper _mapper;

        public BookController(BookDbContext context, IMapper mapper)
        {

            _context = context;
            _mapper = mapper;
        }


        //create a new book
        [HttpPost]
        public IActionResult CreateBook([FromBody] CreateBookDto bookDto)
        {

            Book book = _mapper.Map<Book>(bookDto);

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
                ReadBookDto readBookDto = _mapper.Map<ReadBookDto>(book);

                return Ok(readBookDto);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult updateBook(int id, [FromBody] UpdateBookDto bookDto)
        {
            Book book = _context.Books.FirstOrDefault(book => book.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            _mapper.Map(bookDto, book);

            _context.SaveChanges();
            return NoContent();

        }

        [HttpDelete("{id}")]
        public IActionResult deleteBook(int id)
        {
            Book book = _context.Books.FirstOrDefault(book => book.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            _context.Remove(book);
            _context.SaveChanges();
            return NoContent();
        }
    }
}

