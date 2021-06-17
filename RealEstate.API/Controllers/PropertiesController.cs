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
