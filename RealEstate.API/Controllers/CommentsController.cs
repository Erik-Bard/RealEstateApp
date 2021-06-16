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

        [HttpGet("ByRealEstate")]
        [AllowAnonymous]
        public IActionResult RetriveCommentsByRealEstate(Guid id, int skip, int take)
        {

            if (skip == default)
                skip = 0;

            if (take == default)
                take = 10;

            var comments = _repositoryAccess.Comment.GetCommentsByAdvertisment(false, id);

            comments = comments.Skip(skip).Take(take);

            return Ok(comments);

        }

        [Authorize]
        [HttpPost]
        public IActionResult CreateComment(CommentCreationDto comment)
        {
            if (comment == null)
            {
                _logger.Error("Object is null");
                return BadRequest("Object Is Null.");
            }

            var commentEntity = _mapper.Map<Comment>(comment);

            // Get logged in user
            var getLoggedInUsername = HttpContext.User.Identity.Name.ToString();
            var userLoggedIn = _userRepository.UserRepository.GetUser(getLoggedInUsername, false);
            
            commentEntity.UserId = userLoggedIn.UserId;
            commentEntity.CreatedOn = DateTime.Now;

            _repositoryAccess.Comment.CreateComment(commentEntity);

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

            comments = comments.Skip(skip).Take(take);

            return Ok(comments);

        }


    }
}
