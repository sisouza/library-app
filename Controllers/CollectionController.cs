
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
    public class CollectionController : ControllerBase
    {
        private BookDbContext _context;
        private IMapper _mapper;

        public CollectionController(BookDbContext context, IMapper mapper)
        {

            _context = context;
            _mapper = mapper;
        }


        //create a new book
        [HttpPost]
        public IActionResult CreateCollection([FromBody] CreateCollectionDto collectionDto)
        {

            Collection collection = _mapper.Map<Collection>(collectionDto);

            _context.Collections.Add(collection);
            _context.SaveChanges();
            return CreatedAtAction(nameof(getById), new { Id = collection.Id }, collection);

        }

        [HttpGet]
        public IEnumerable<Collection> getAll()
        {
            return _context.Collections;
        }


        [HttpGet("{id}")]
        public IActionResult getById(int id)
        {
            Collection collection = _context.Collections.FirstOrDefault(collection => collection.Id == id);

            if (collection != null)
            {
                ReadCollectionDto readCollectionDto = _mapper.Map<ReadCollectionDto>(collection);

                return Ok(readCollectionDto);
            }
            return NotFound();
        }


    }
}

