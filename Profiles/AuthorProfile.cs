using AutoMapper;
using library_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using library_app.Data.Dtos;

namespace library_app.Profiles
{

    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<CreateAuthorDto, Author>();
            CreateMap<Author, ReadAuthorDto>()
                .ForMember(author => author.Books, opts => opts
                .MapFrom(author => author.Books.Select
                (b => new { b.Id, b.Title, b.Year, b.Genre })));
            CreateMap<UpdateAuthorDto, Author>();
        }
    }

}
