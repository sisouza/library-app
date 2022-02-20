using AutoMapper;
using library_app.Models;

namespace library_app.Profiles
{
    public class BookProfile : Profile
    {
        public class BookProfile()
        {
            CreateMap<CreateBookDto, Book>();
            CreateMap<Book, ReadBookDto>();
            CreateMap<UpdateBookDto, Book>();
        }
}
}
