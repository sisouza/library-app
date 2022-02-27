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
    public class CollectionService
    {
        private BookDbContext _context;
        private IMapper _mapper;

        public CollectionService(BookDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadCollectionDto Create(CreateCollectionDto collectionDto)
        {
            Collection collection = _mapper.Map<Collection>(collectionDto);
            _context.Collections.Add(collection);
            _context.SaveChanges();
            return _mapper.Map<ReadCollectionDto>(collection);
        }

        public List<ReadCollectionDto> GetAll()
        
        {
            List<Collection> collections = _context.Collections.ToList();

            if (collections != null)
            {
                return _mapper.Map<List<ReadCollectionDto>>(collections);
            }
            return null;
        }

        public ReadCollectionDto GetById(int id)
        {

            Collection collection = _context.Collections.FirstOrDefault(collection => collection.Id == id);

            if (collection != null)
            {
                ReadCollectionDto readCollectionDto = _mapper.Map<ReadCollectionDto>(collection);

                return readCollectionDto;
            }
            return null;
        }

        public Result DeleteCollection(int id)
        {
            Collection collection = _context.Collections.FirstOrDefault(collection => collection.Id == id);
            if (collection == null)
            {
                return Result.Fail("Collection not found");
            }
            _context.Remove(collection);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
