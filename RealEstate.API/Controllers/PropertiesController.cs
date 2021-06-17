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
    [Route("api/Properties")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        private readonly IRepositoryManager _repositoryAccess;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;

        public PropertiesController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            this._repositoryAccess = repository;
            this._mapper = mapper;
            this._logger = logger;
        }

        /// <summary>
        /// Retrieve all properties
        /// </summary>
        /// <remarks>
        /// Remember, Properties ARE NOT the same thing as Advertisement/RealEstates.
        /// Properties are the buildings themself and not the full sale advertisement
        /// </remarks>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetProperties()
        {
            var properties = _repositoryAccess.Property.GetAllProperties(trackChanges:false);

            if (properties == null)
            {
                _logger.Error("Properties tried to be accessed from database doesnt exist.");
                return NotFound("Properties doesnt exist in the database");
            }

            var propertiesDto = _mapper.Map<IEnumerable<PropertyDto>>(properties);

            return Ok(propertiesDto);
        }

        /// <summary>
        /// Get A Property by an Id
        /// </summary>
        /// <remarks>
        /// Retrieve a Property by supplying a valid Id for that property.
        /// 
        /// Example Schema:
        /// 
        ///     Get/{id}
        ///     {
        ///         "id" : "c38d946f-8f03-4634-af86-c518ded8989f"
        ///     }
        /// 
        /// </remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "PropertyById")]
        public IActionResult GetPropertiesById(Guid id)
        {
            var properties = _repositoryAccess.Property.GetProperty(id, trackChanges: false);

            if (properties != null)
            {
                var propertiesDto = _mapper.Map<PropertyDto>(properties);
                return Ok(propertiesDto);
            }
            else
            {
                _logger.Info($"Property with id {id} does not exist.");
                return NotFound();
            }
        }

        /// <summary>
        /// Create/Post a new Property
        /// </summary>
        /// <remarks>
        /// Creating/Posting a new property so that it might be used to be sold in an advertisement.
        /// 
        /// Example Schema:
        /// 
        ///     Post/Properties
        ///     {
        ///         "constructionYear" : 2020,
        ///         "address" : "420 Björkvägen 69A"
        ///     }
        /// 
        /// </remarks>
        /// <param name="property"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        public IActionResult CreatePropertyAd([FromBody] PropertyCreationDto property)
        {
            if (!ModelState.IsValid)
            {
                _logger.Error($"Invalid modelstate of: {ModelState}");
                return UnprocessableEntity(ModelState);
            }

            if (property == null)
            {
                _logger.Error("Property object sent from client is Null.");
                return NotFound("Object Is Null.");
            }

            var propertyEntity = _mapper.Map<Property>(property);

            _repositoryAccess.Property.CreateProperty(propertyEntity);
            _repositoryAccess.Save();

            var propertyToReturn = _mapper.Map<PropertyDto>(propertyEntity);

            return CreatedAtRoute("PropertyById",
                new { id = propertyToReturn.Id },
                propertyToReturn);
        }

        /// <summary>
        /// Retrieve Properties with Paging
        /// </summary>
        /// <remarks>
        /// Retrieve 1 or more Properties with Paging supplying an Id.
        /// 
        ///     Get/SkipTake
        ///     {
        ///         "id" : "c38d946f-8f03-4634-af86-c518ded8989f"
        ///     }
        /// 
        /// </remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("SkipTake")]
        [AllowAnonymous]
        public async Task<ActionResult> RetrievePropertiesSkipTake(Guid id)
        {
            var property = _repositoryAccess.Property.GetProperty(id, trackChanges: false);

            if (property == null)
            {
                _logger.Error("Property object sent from client is Null.");
                return NotFound("Object Is Null.");
            }

            await Task.CompletedTask;

            return Ok(property);
        }
    }
}
