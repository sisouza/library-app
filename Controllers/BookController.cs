using System.Collections.Generic;
using library_app.Data.Dtos;
using Microsoft.AspNetCore.Mvc;
using library_app.Services;
using FluentResults;

namespace library_app.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {

        private BookService _bookService;

        public BookController(BookService bookService)
        {

            _bookService = bookService;
        }


        //create a new book
        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult CreateBook([FromBody] CreateBookDto bookDto)
        {

            ReadBookDto readBookDto = _bookService.Create(bookDto);
            return CreatedAtAction(nameof(getById), new { Id = readBookDto.Id }, readBookDto);

        }

        [HttpGet]
        public IActionResult getAll()
        {
            List<ReadBookDto> readBookDto = _bookService.GetAll();
            if (readBookDto != null) return Ok(readBookDto);
            return NotFound();
        }

        [HttpGet("{year}")]
        public IActionResult getByReleaseYear([FromQuery] int? year = null)
        {
            List<ReadBookDto> readBookDto = _bookService.GetByYear(year);
            if (readBookDto != null) return Ok(readBookDto);
            return NotFound();
        }


        [HttpGet("{id}")]
        public IActionResult getById(int id)
        {
            ReadBookDto readBookDto = _bookService.GetById(id);
            if (readBookDto != null) return Ok(readBookDto);
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult updateBook(int id, [FromBody] UpdateBookDto bookDto)
        {
            Result result = _bookService.UpdateBook(id, bookDto);
            if (result.IsFailed) return NotFound();
            return NoContent();

        }

        [HttpDelete("{id}")]
        public IActionResult deleteBook(int id)
        {
            Result result = _bookService.DeleteBook(id);
            if (result.IsFailed) return NotFound();
            return NoContent();
        }
    }
}

