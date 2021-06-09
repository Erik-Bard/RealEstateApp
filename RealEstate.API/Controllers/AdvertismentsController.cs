using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace RealEstate.API.Controllers
{
    [Route("api/RealEstates")]
    [ApiController]
    public class AdvertismentsController : ControllerBase
    {
        private readonly IRepositoryManager _repositoryAccess;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;

        public AdvertismentsController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            this._repositoryAccess = repository;
            this._mapper = mapper;
            this._logger = logger;
        }

        [HttpGet]
        public IActionResult GetAdvertisments()
        {
            var advertisments = _repositoryAccess.Advertisment.GetAllAdvertisments(trackChanges: false);

            var advertismentsDto = _mapper.Map<IEnumerable<AdvertismentsDto>>(advertisments);

            return Ok(advertismentsDto);
        }

        [HttpGet("{id}", Name = "AdvertismentById")]
        public IActionResult GetAdvertisment(Guid id)
        {
            var advertisment = _repositoryAccess.Advertisment.GetAdvertisment(id, trackChanges: false);
            var property = _repositoryAccess.Property.GetProperty(advertisment.PropertyId, trackChanges: false);

            if(advertisment != null)
            {
                var advertismentDto = new AdvertismentDto
                {
                    CreatedOn = advertisment.CreatedOn,
                    ConstructionYear = property.YearOfConstruction,
                    Address = property.Address,
                    PropertyType = advertisment.PropertyType,
                    Description = advertisment.Description,
                    Id = advertisment.Id,
                    Title = advertisment.Title,
                    SellingPrice = advertisment.SellingPrice,
                    RentingPrice = advertisment.RentingPrice,
                    CanBeSold = advertisment.CanBeSold,
                    CanBeRented = advertisment.CanBeRented
                };

                return Ok(advertismentDto);
            }
            else
            {
                _logger.Info($"Advertisment id: {id} was not found.");
                return NotFound();
            }
        }

        //[Authorize]
        //[HttpPost]
        //public IActionResult CreateAdvertisment([FromBody] AdvertismentCreationDto advertisment)
        //{
           
        //}

        //[HttpGet("SkipTake")]
        //[AllowAnonymous]
        //public async Task<ActionResult> RetrieveAdvertismentSkipTake(Guid id)
        //{
            
        //}
    }
}
