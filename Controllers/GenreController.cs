using System.Collections.Generic;
using library_app.Data.Dtos;
using Microsoft.AspNetCore.Mvc;
using library_app.Services;
using FluentResults;

namespace library_app.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GenreController : ControllerBase
    {
        private GenreService _genreService;

        public GenreController(GenreService genreService)
        {

            _genreService = genreService;
        }


        [HttpPost]
        public IActionResult CreateGenre([FromBody] CreateGenreDto genreDto)
        {

            ReadGenreDto readGenreDto = _genreService.Create(genreDto);
            return CreatedAtAction(nameof(getById), new { Id = readGenreDto.Id }, readGenreDto);

        }

        [HttpGet]
        public IActionResult getAll()
        {
            List<ReadGenreDto> readGenreDto = _genreService.GetAll();
            if (readGenreDto != null) return Ok(readGenreDto);
            return NotFound();
        }


        [HttpGet("{id}")]
        public IActionResult getById(int id)
        {
            ReadGenreDto readGenreDto = _genreService.GetById(id);
            if (readGenreDto != null) return Ok(readGenreDto);
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateGenreDto genreDto)
        {
            Result result = _genreService.Update(id, genreDto);
            if (result.IsFailed) return NotFound();
            return NoContent();
        }

    }
}

