
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using library_app.Data;
using library_app.Data.Dtos;
using library_app.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using library_app.Services;

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
        public IActionResult CreateBook([FromBody] CreateBookDto bookDto)
        {

            ReadBookDto readBookDto = _bookService.Create(bookDto);
            return CreatedAtAction(nameof(getById), new { Id = readBookDto.Id }, readBookDto);

        }

        [HttpGet]
        public ActionResult<Book> getAll()
        {
            List<ReadBookDto> readBookDto = _bookService.GetAll();
            if (readBookDto != null) return Ok(readBookDto);
            return NotFound();
        }

        [HttpGet]
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
            Result resul = _bookService.UpdateBook(id, bookDto);
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

