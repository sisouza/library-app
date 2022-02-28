
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using library_app.Data;
using library_app.Data.Dtos;
using library_app.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using library_app.Services;

namespace library_app.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CollectionController : ControllerBase
    {
        private CollectionService _collectionService;

        public CollectionController(CollectionService collectionService)
        {

            _collectionService = collectionService;
        }


        //create a new book
        [HttpPost]
        public IActionResult CreateCollection([FromBody] CreateCollectionDto collectionDto)
        {

            ReadCollectionDto readCollectionDto = _collectionService.Create(collectionDto);
            return CreatedAtAction(nameof(getById), new { Id = readCollectionDto.Id }, readCollectionDto);
        }

        [HttpGet]
        public IActionResult getAll()
        {
            List<ReadCollectionDto> readCollectionDto = _collectionService.GetAll();
            if (readCollectionDto != null) return Ok(readCollectionDto);
            return NotFound();
        }


        [HttpGet("{id}")]
        public IActionResult getById(int id)
        {
            ReadCollectionDto readCollectionDto = _collectionService.GetById(id);
            if (readCollectionDto != null) return Ok(readCollectionDto);
            return NotFound();
        }


    }
}

