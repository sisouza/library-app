
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
    public class GenreController : ControllerBase
    {
        private BookDbContext _context;
        private IMapper _mapper;

        public GenreController(BookDbContext context, IMapper mapper)
        {

            _context = context;
            _mapper = mapper;
        }


        [HttpPost]
        public IActionResult CreateGenre([FromBody] CreateGenreDto genreDto)
        {

            Genre genre = _mapper.Map<Genre>(genreDto);

            _context.Genres.Add(genre);
            _context.SaveChanges();
            return CreatedAtAction(nameof(getById), new { Id = genre.Id }, genre);

        }

        [HttpGet]
        public IEnumerable<Genre> getAll()
        {
            return _context.Genres;
        }



        [HttpGet("{id}")]
        public IActionResult getById(int id)
        {
            Genre genre = _context.Genres.FirstOrDefault(genre => genre.Id == id);

            if (genre != null)
            {
                ReadGenreDto readGenreDto = _mapper.Map<ReadGenreDto>(genre);

                return Ok(readGenreDto);
            }
            return NotFound();
        }


        [HttpDelete("{id}")]
        public IActionResult deleteGenre(int id)
        {
            Genre genre = _context.Genres.FirstOrDefault(genre => genre.Id == id);
            if (genre == null)
            {
                return NotFound();
            }
            _context.Remove(genre);
            _context.SaveChanges();
            return NoContent();
        }
    }
}

