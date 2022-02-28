using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FluentResults;
using library_app.Data;
using library_app.Data.Dtos;
using library_app.Models;

namespace library_app.Services
{
    public class GenreService
    {
        private BookDbContext _context;
        private IMapper _mapper;

        public GenreService(BookDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadGenreDto Create(CreateGenreDto genreDto)
        {
            Genre genre = _mapper.Map<Genre>(genreDto);
            _context.Genres.Add(genre);
            _context.SaveChanges();
            return _mapper.Map<ReadGenreDto>(genre);
        }


        public List<ReadGenreDto> GetAll()

        {
            List<Genre> genres = _context.Genres.ToList();

            if (genres != null)
            {
                return _mapper.Map<List<ReadGenreDto>>(genres);
            }
            return null;
        }

        public ReadGenreDto GetById(int id)
        {

            Genre genre = _context.Genres.FirstOrDefault(genre => genre.Id == id);

            if (genre != null)
            {
                ReadGenreDto readgenreDto = _mapper.Map<ReadGenreDto>(genre);

                return readgenreDto;
            }
            return null;
        }

        public Result Update(int id, UpdateGenreDto genreDto)
        {
            Genre genre = _context.Genres.FirstOrDefault(genre  => genre .Id == id);
            if (genre  == null)
            {
                return Result.Fail("Genre not found");
            }
            _mapper.Map(genreDto, genre);
            _context.SaveChanges();
            return Result.Ok();
        }


        public Result DeleteGenre(int id)
        {
            Genre genre = _context.Genres.FirstOrDefault(genre => genre.Id == id);
            if (genre == null)
            {
                return Result.Fail("Genre not found");
            }
            _context.Remove(genre);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}

