
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
    public class AuthorController : ControllerBase
    {
        private BookDbContext _context;
        private IMapper _mapper;

        public AuthorController(BookDbContext context, IMapper mapper)
        {

            _context = context;
            _mapper = mapper;
        }


        //create a new book
        [HttpPost]
        public IActionResult CreateAuthor([FromBody] CreateAuthorDto authorDto)
        {

            Author author = _mapper.Map<Author>(authorDto);

            _context.Authors.Add(author);
            _context.SaveChanges();
            return CreatedAtAction(nameof(getById), new { Id = author.Id }, author);

        }

        [HttpGet]
        public IEnumerable<Author> getAll()
        {
            return _context.Authors;
        }


        [HttpGet("{id}")]
        public IActionResult getById(int id)
        {
            Author author = _context.Authors.FirstOrDefault(author => author.Id == id);

            if (author != null)
            {
                ReadAuthorDto readAuthorDto = _mapper.Map<ReadAuthorDto>(author);

                return Ok(readAuthorDto);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult updateAuthor(int id, [FromBody] UpdateAuthorDto authorDto)
        {
            Author author = _context.Authors.FirstOrDefault(author => author.Id == id);
            if (author == null)
            {
                return NotFound();
            }
            _mapper.Map(authorDto, author);

            _context.SaveChanges();
            return NoContent();

        }

        [HttpDelete("{id}")]
        public IActionResult deleteAuthor(int id)
        {
            Author author = _context.Authors.FirstOrDefault(author => author.Id == id);
            if (author == null)
            {
                return NotFound();
            }
            _context.Remove(author);
            _context.SaveChanges();
            return NoContent();
        }
    }
}

