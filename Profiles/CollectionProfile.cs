using AutoMapper;
using library_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using library_app.Data.Dtos;

namespace library_app.Profiles
{

    public class CollectionProfile : Profile
    {
        public CollectionProfile()
        {
            CreateMap<CreateCollectionDto, Collection>();
            CreateMap<Collection, ReadCollectionDto>();

        }
    }

}
