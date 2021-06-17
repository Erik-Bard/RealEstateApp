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
    [Route("api/Comments")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IRepositoryManager _repositoryAccess;
        private readonly IUserManagerRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;

        public CommentController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper, IUserManagerRepository userRepository)
        {
            this._repositoryAccess = repository;
            this._mapper = mapper;
            this._logger = logger;
            this._userRepository = userRepository;
        }

        [HttpGet("ByRealEstate", Name = "CommentById")]
        [AllowAnonymous]
        public IActionResult RetriveCommentsByRealEstate(Guid id, int skip, int take)
        {
            if (skip == default)
                skip = 0;

            if (take == default)
                take = 10;

            var comments = _repositoryAccess.Comment.GetCommentsByAdvertisment(false, id);

            if (comments == null)
            {
                _logger.Error("Request to get Comments returned Null value.");
                return NotFound("Comments returned Null");
            }

            comments = comments.Skip(skip).Take(take);

            return Ok(comments);

        }

        [Authorize]
        [HttpPost]
        public IActionResult CreateComment([FromBody] CommentCreationDto comment)
        {
            if (!ModelState.IsValid)
            {
                _logger.Error($"Invalid modelstate of: {ModelState}");
                return UnprocessableEntity(ModelState);
            }

            if (comment == null)
            {
                _logger.Error("Object is null");
                return NotFound("Object Is Null.");
            }

            var commentEntity = _mapper.Map<Comment>(comment);

            // Get logged in user
            var getLoggedInUsername = HttpContext.User.Identity.Name.ToString();
            var userLoggedIn = _userRepository.UserRepository.GetUser(getLoggedInUsername, false);
            
            commentEntity.UserId = userLoggedIn.UserId;
            commentEntity.CreatedOn = DateTime.Now;
            commentEntity.Id = Guid.NewGuid();

            _repositoryAccess.Comment.CreateComment(commentEntity);
            _repositoryAccess.Save();

            return CreatedAtRoute("CommentById",
                new { id = commentEntity.Id },
                commentEntity);
        }


        [HttpGet("ByUser")]
        [AllowAnonymous]
        public IActionResult RetriveCommentsSkipTakeByUser(string userName, int skip, int take)
        {
            if (skip == default)
                skip = 0;

            if (take == default)
                take = 10;

            var user = _userRepository.UserRepository.GetUser(userName, false);

            var comments = _repositoryAccess.Comment.GetCommentsByUserId(false, user.UserId);

            if (comments == null)
            {
                _logger.Error("Request to get Comments returned Null value.");
                return NotFound("Comments returned Null");
            }

            comments = comments.Skip(skip).Take(take);

            return Ok(comments);

        }


    }
}
