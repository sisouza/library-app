
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
using FluentResults;

namespace library_app.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorController : ControllerBase
    {
        private AuthorService _authorService;
        public AuthorController(AuthorService authorService)
        {
            _authorService = authorService;
        }


        [HttpPost]
        public IActionResult CreateAuthor([FromBody] CreateAuthorDto authorDto)
        {

            ReadAuthorDto readAuthorDto = _authorService.Create(authorDto);
            return CreatedAtAction(nameof(getById), new { Id = readAuthorDto.Id }, readAuthorDto);

        }

        [HttpGet]
        public ActionResult<Author> getAll()
        {
            List<ReadAuthorDto> readAuthorDto = _authorService.GetAll();
            if (readAuthorDto != null) return Ok(readAuthorDto);
            return NotFound();
        }


        [HttpGet("{id}")]
        public IActionResult getById(int id)
        {
            ReadAuthorDto readAuthorDto = _authorService.GetById(id);

            if (readAuthorDto != null) return Ok(readAuthorDto);
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult updateAuthor(int id, [FromBody] UpdateAuthorDto authorDto)
        {
            Result result = _authorService.UpdateAuthor(id, authorDto);
            if (result.IsFailed) return NotFound();
            return NoContent();

        }

        [HttpDelete("{id}")]
        public IActionResult deleteAuthor(int id)
        {
            Result result = _authorService.DeleteAuthor(id);
            if (result.IsFailed) return NotFound();
            return NoContent();
        }
    }
}

