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

        /// <summary>
        /// Get Comments for a RealEstate
        /// </summary>
        /// <remarks>
        /// Retrieve Comments written about a RealEstate,
        /// Provide a Valid RealEstate's Id
        /// 
        ///     Get/ByRealEstate
        ///     {
        ///         "id" : "b5c1ffaa-a41d-40f2-b59c-c9611dea7b70",
        ///         "skip" : "2",
        ///         "take" : "5"
        ///     }
        /// 
        /// </remarks>
        /// <param name="id"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        [HttpGet("/ID", Name = "CommentById")]
        [Authorize]
        public IActionResult RetriveCommentsByRealEstate(Guid id, int skip, int take)
        {
            if (skip == default)
                skip = 0;

            if (take == default)
                take = 10;

            if (take > 100)
            {
                _logger.Warning("User tried to use Take paging action above 100.");
                return BadRequest("Cannot provide Take paging request above 100.");
            }

            var comments = _repositoryAccess.Comment.GetCommentsByAdvertisment(false, id);

            if (comments.Count() <= 0 || comments == null)
            {
                _logger.Error("Request to get Comments returned Null value.");
                return NotFound("Comments returned Null");
            }

            comments = comments.Skip(skip).Take(take);

            var listOfComments = comments.ToList();

            List<CommentResponseDto> commentResponsesDtos = new List<CommentResponseDto>();

            CommentResponseDto CommentDto = new CommentResponseDto();

            foreach (var comment in listOfComments)
            {

                var guid = new Guid(comment.UserId);
                var user = _userRepository.UserRepository.GetUserByGuid(guid, false);
                if (user == null)
                {
                    _logger.Error("User wanted to retrieve doesnt exist in db");
                    return NotFound("User doesnt exist");
                }
                CommentResponseDto CommentEntity = new CommentResponseDto
                {
                    Content = comment.Content,
                    UserName = user.UserName,
                    CreatedOn = comment.CreatedOn
                };
                commentResponsesDtos.Add(CommentEntity);
            }

            return Ok(commentResponsesDtos.OrderBy(x => x.CreatedOn));

        }

        /// <summary>
        /// Create/Send/Make a new comment
        /// </summary>
        /// <remarks>
        /// New Comment with a valid Advertisement's Id
        /// Example Schema:
        /// 
        ///     Post/Comments
        ///     {
        ///         "AdvertismentId" : "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        ///         "Content" : "Jättefin lägenhet med bra utsikt över Kungsparken!"
        ///     }
        /// 
        /// </remarks>
        /// <param name="comment"></param>
        /// <returns></returns>
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


        /// <summary>
        /// Get Comments by a User, with Skip and Take paging actions
        /// </summary>
        /// <remarks>
        /// Retrieve Comments written,
        /// Provide an existing User's Username.
        /// 
        ///     Get/ByUser
        ///     {
        ///         "userName" : "KalleKalas",
        ///         "skip" : "2",
        ///         "take" : "5"
        ///     }
        /// 
        /// </remarks>
        /// <param name="userName"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        [HttpGet("ByUser/USERNAME/SkipTake")]
        [Authorize]
        public IActionResult RetriveCommentsSkipTakeByUser(string userName, int skip, int take)
        {
            if (skip == default)
                skip = 0;

            if (take == default)
                take = 10;

            if (take > 100)
            {
                _logger.Warning("User tried to use Take paging action above 100.");
                return BadRequest("Cannot provide Take paging request above 100.");
            }

            var user = _userRepository.UserRepository.GetUser(userName, false);

            if (user == null)
            {
                _logger.Error("User wanted to retrieve doesnt exist in db");
                return NotFound("User doesnt exist");
            }

            var comments = _repositoryAccess.Comment.GetCommentsByUserId(false, user.UserId);

            if (comments.Count() <= 0 || comments == null)
            {
                _logger.Error("Request to get Comments returned Null value.");
                return NotFound("Comments returned Null");
            }

            comments = comments.Skip(skip).Take(take);
            var listOfComments = comments.ToList();

            List<CommentResponseDto> commentResponsesDtos = new List<CommentResponseDto>();

            CommentResponseDto CommentDto = new CommentResponseDto();

            foreach (var comment in listOfComments)
            {
                CommentResponseDto CommentEntity = new CommentResponseDto
                {
                    Content = comment.Content,
                    UserName = user.UserName,
                    CreatedOn = comment.CreatedOn
                };
                commentResponsesDtos.Add(CommentEntity);
            }

            return Ok(commentResponsesDtos.OrderBy(x => x.CreatedOn));

        }

        /// <summary>
        /// Get a User and their comments in descending order after CreatedOn date.
        /// </summary>
        /// <remarks>
        /// Provide an existing User's username and get back its comments.
        /// 
        /// Example Schema:
        /// 
        ///     Get/ByUser/Username
        ///     {
        ///         "username" : "KalleKalas"
        ///     }
        ///     
        /// </remarks>
        /// <param name="userName"></param>
        /// <returns></returns>
        [HttpGet("ByUser/USERNAME")]
        [Authorize]
        public IActionResult GetCommentsByUserUsername(string userName)
        {
            int skip = 0;
            int take = 0;

            if (skip == default)
                skip = 0;

            if (take == default)
                take = 10;

            var user = _userRepository.UserRepository.GetUser(userName, false);
            var comments = _repositoryAccess.Comment.GetCommentsByUserId(false, user.UserId);

            if (comments.Count() <= 0 || comments == null)
            {
                _logger.Error("Request to get Comments returned Null value.");
                return NotFound("Comments returned Null");
            }

            var listOfComments = comments.ToList();

            List<CommentResponseDto> commentResponsesDtos = new List<CommentResponseDto>();

            CommentResponseDto CommentDto = new CommentResponseDto();

            foreach (var comment in listOfComments)
            {
                CommentResponseDto CommentEntity = new CommentResponseDto
                {
                    Content = comment.Content,
                    UserName = user.UserName,
                    CreatedOn = comment.CreatedOn
                };
                commentResponsesDtos.Add(CommentEntity);
            }

            return Ok(commentResponsesDtos.OrderBy(x => x.CreatedOn));
        }
    }
}
