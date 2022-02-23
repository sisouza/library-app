

using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using library_app.Data;
using library_app.Data.Dtos;
using library_app.Models;

namespace library_app.Services
{
    public class BookService
    {
        private BookDbContext _context;
        private IMapper _mapper;

        public BookService(BookDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadBookDto Create(CreateBookDto bookDto)
        {
            Book book = _mapper.Map<Book>(bookDto);
            _context.Books.Add(book);
            _context.SaveChanges();
            return _mapper.Map<ReadBookDto>(book);
        }

        public List<ReadBookDto>GetByYear(int? year)
        {
            List<Book> books;

            if (year == null)
            {
                books = _context.Books.ToList();

            }
            else
            {
                books = _context
                .Books.Where(book => book.Year <= year).ToList();
            }


            if (books != null)
            {
                List<ReadBookDto> readDto = _mapper.Map<List<ReadBookDto>>(books);
                return readDto;
            }

            return null;
        }

        public ReadBookDto GetAll()
        {
            Book books = _context.Books.All();

            if (books != null)
            {
                ReadBookDto readBookDto = _mapper.Map<ReadBookDto>(books);

                return readBookDto;
            }
            return null;
        }

        public ReadBookDto GetById(int id)
        {

            Book book = _context.Books.FirstOrDefault(book => book.Id == id);

            if (book != null)
            {
                ReadBookDto readBookDto = _mapper.Map<ReadBookDto>(book);

                return readBookDto;
            }
            return null;
        }

             public Result UpdateBook(int id, UpdateBookDto bookDto)
        {
            Book book = _context.Books.FirstOrDefault(book => book.Id == id);
            if (book == null)
            {
                return Result.Fail("Book not found");
            }
            _mapper.Map(bookDto, book);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeleteBook(int id)
        {
            Book book = _context.Books.FirstOrDefault(book => book.Id == id);
            if (book == null)
            {
                return Result.Fail("Book not found");
            }
            _context.Remove(book);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
