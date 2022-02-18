using AutoMapper;
using library_app.Models;

public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<CreateBookDto, Book>();
            CreateMap<Book, ReadFilmeDto>();
            CreateMap<UpdateBookDto,  Book>();
        }
    }