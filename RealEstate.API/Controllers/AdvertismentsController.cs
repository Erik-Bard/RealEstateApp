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

        /// <summary>
        /// Get all Advertisements
        /// </summary>
        /// <remarks>
        /// Simple HttpGet call to retrieve all Advertisements
        /// </remarks>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAdvertisments()
        {
            var advertisments = _repositoryAccess.Advertisment.GetAllAdvertisments(trackChanges: false);

            if (advertisments == null)
            {
                _logger.Error("advertisment is null, check id or if it doesnt exist.");
                return NotFound("Advertisement object is null");
            }

            var advertismentsDto = _mapper.Map<IEnumerable<AdvertismentsDto>>(advertisments);

            return Ok(advertismentsDto);
        }

        /// <summary>
        /// Get an Advertisement
        /// </summary>
        /// <remarks>
        /// Example values | Schema:
        ///     
        ///     Get/RealEstates/{id}
        ///     {
        ///         "id" : "e5c390d8-effd-4fff-8b5c-171ed66a09b5"
        ///     }
        /// 
        /// </remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "AdvertismentById")]
        [AllowAnonymous]
        public IActionResult GetAdvertismentById(Guid id)
        {
            var advertisment = _repositoryAccess.Advertisment.GetAdvertisment(id, trackChanges: false);

            if (advertisment == null)
            {
                _logger.Error("advertisment is null, check id or if it doesnt exist.");
                return NotFound("Advertisement object is null");
            }

            var property = _repositoryAccess.Property.GetProperty(advertisment.PropertyId, trackChanges: false);

            if (property == null)
            {
                _logger.Error("Property entity returned null, check id or if it doesnt exist.");
                return NotFound("Property is null");
            }

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

        /// <summary>
        /// Get Advertisement and Comments, Require Login.
        /// </summary>
        /// <remarks>
        /// Example values | Schema:
        ///     
        ///     Get/RealEstates/{Id}
        ///     {
        ///         "id" : "e5c390d8-effd-4fff-8b5c-171ed66a09b5"
        ///     }
        /// 
        /// </remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet()]
        [Route("Id")]
        [Authorize]
        public IActionResult GetAdvertismentPrivate(Guid id)
        {
            var advertisment = _repositoryAccess.Advertisment.GetAdvertisment(id, trackChanges: false);

            if (advertisment == null)
            {
                _logger.Error("advertisment is null, check id or if it doesnt exist.");
                return NotFound("Advertisement object is null");
            }

            var property = _repositoryAccess.Property.GetProperty(advertisment.PropertyId, trackChanges: false);

            if (property == null)
            {
                _logger.Error("Property entity returned null, check id or if it doesnt exist.");
                return NotFound("Property is null");
            }

            var comments = _repositoryAccess.Comment.GetCommentsByAdvertisment(false, advertisment.Id).ToList();

            if (advertisment != null)
            {
                var advertismentPrivateDto = new AdvertisementPrivateDto
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
                    CanBeRented = advertisment.CanBeRented,
                    Contact = advertisment.Contact,
                    Comments = comments
                };


                return Ok(advertismentPrivateDto);
            }
            else
            {
                _logger.Info($"Advertisment id: {id} was not found.");
                return NotFound();
            }
        }


        /// <summary>
        /// Create a new Advertisement for a RealEstate
        /// </summary>
        /// <remarks>
        /// You must be logged in to perform this.
        /// Example values | Schema:
        /// 
        ///     Post /RealEstates
        ///     {
        ///         "title" : "Fin etta på Lindholmen",
        ///         "description" : "Fin etta på Lindholmen i ett grönt och fint område. Väldigt barnvänligt och bra koppling med lokaltrafiken.",
        ///         "contact" : "0551-1523-124-125",
        ///         "yearOfConstruction": 2020,
        ///          "sellingPrice": 10000,
        ///          "rentingPrice": 100,
        ///          "propertyType": 1
        ///     }
        ///     
        /// </remarks>
        /// <param name="advertisment"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        public IActionResult CreateAdvertisment([FromBody] AdvertismentCreationDto advertisment)
        {
            if (!ModelState.IsValid)
            {
                _logger.Error($"Invalid modelstate of: {ModelState}");
                return UnprocessableEntity(ModelState);
            }

            if (advertisment == null)
            {
                _logger.Error("Object is null");
                return NotFound("Object Is Null.");
            }

            // Add the property to db
            var propertyEntity = _mapper.Map<Property>(advertisment);
            _repositoryAccess.Property.CreateProperty(propertyEntity);
            
            //Add the advertisment to db.
            var advertismentEntity = _mapper.Map<Advertisment>(advertisment);
            Guid id = Guid.NewGuid();
            advertismentEntity.CanBeSold = true;
            advertismentEntity.CanBeRented = true;
            advertismentEntity.PropertyId = propertyEntity.Id;

            _repositoryAccess.Advertisment.CreateAdvertisment(advertismentEntity);
            _repositoryAccess.Save();

            var returnModel = _mapper.Map<AdvertismentResponseDto>(advertismentEntity);

            return CreatedAtRoute("AdvertismentById",
                new { id = returnModel.Id },
                returnModel);
        }

        /// <summary>
        /// Request Pager from X page to Z
        /// </summary>
        /// <remarks>
        /// Example values | Schema:
        /// 
        ///     Get /SkipTake
        ///     {
        ///         "Skip" : 2,
        ///         "Take" : 5
        ///     }
        /// 
        /// </remarks>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        [HttpGet("SkipTake")]
        [AllowAnonymous]
        public IActionResult RetrieveAdvertismentSkipTake(int skip, int take)
        {
            var ads  = _repositoryAccess.Advertisment.GetAllAdvertisments(trackChanges: false);

            if (ads == null)
            {
                _logger.Error("advertisment is null, check id or if it doesnt exist.");
                return NotFound("Advertisement object is null");
            }

            if (skip == default)
                skip = 0;

            if (take == default)
                take = 10;

            // Order ads list by createdOn
            ads = ads.OrderByDescending(e => e.CreatedOn);

            // Skip Take Result
            ads = ads.Skip(skip).Take(take);


            List<AdvertismentResponseDto> responseList = new List<AdvertismentResponseDto>();

            //Add Mapped Objects to responseList
            foreach (var item in ads)
            {
                var returnEntity = _mapper.Map<AdvertismentResponseDto>(item);

                responseList.Add(returnEntity);

            }

            return Ok(responseList);
        }
    }
}
