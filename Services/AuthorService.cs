

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
    public class AuthorService
    {
        private BookDbContext _context;
        private IMapper _mapper;

        public AuthorService(BookDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadAuthorDto Create(CreateAuthorDto authorDto)
        {
            Author author = _mapper.Map<Author>(authorDto);
            _context.Authors.Add(author);
            _context.SaveChanges();
            return _mapper.Map<ReadAuthorDto>(author);
        }


        public List<ReadAuthorDto> GetAll()

        {
            List<Author> authors = _context.Authors.ToList();

            if (authors != null)
            {
                return _mapper.Map<List<ReadAuthorDto>>(authors);
            }
            return null;
        }

        public ReadAuthorDto GetById(int id)
        {

            Author author = _context.Authors.FirstOrDefault(author => author.Id == id);

            if (author != null)
            {
                ReadAuthorDto readAuthorDto = _mapper.Map<ReadAuthorDto>(author);

                return readAuthorDto;
            }
            return null;
        }

        public Result UpdateAuthor(int id, UpdateAuthorDto authorDto)
        {
            Author author = _context.Authors.FirstOrDefault(author => author.Id == id);
            if (author == null)
            {
                return Result.Fail("Author not found");
            }
            _mapper.Map(authorDto, author);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeleteAuthor(int id)
        {
            Author author = _context.Authors.FirstOrDefault(author => author.Id == id);
            if (author == null)
            {
                return Result.Fail("Author not found");
            }
            _context.Remove(author);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
