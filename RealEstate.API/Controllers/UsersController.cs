using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using IdentityLibrary.Authentication;
using IdentityLibrary.Models;
using Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate.API.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.API.Controllers
{
    [Route("api/Users")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;
        private readonly IUserManagerRepository _userRepository;
        private readonly IRepositoryManager _repositoryManager;

        public UsersController(ILoggerManager logger,
            IMapper mapper,
            IUserManagerRepository userRepository,
            IRepositoryManager repositoryManager)
        {
            this._mapper = mapper;
            this._logger = logger;
            this._userRepository = userRepository;
            this._repositoryManager = repositoryManager;
        }

        /// <summary>
        /// Get an existing User and its status.
        /// </summary>
        /// <remarks>
        /// Get an Existing User and its status.
        /// 
        ///     GET/{username}
        ///     {
        ///         "username" : "KalleKalas"
        ///     }
        ///     
        /// </remarks>
        /// <param name="username"></param>
        /// <returns></returns>
        [HttpGet("{username}")]
        [AllowAnonymous]
        public IActionResult GetUsers(string username)
        {
            var user = _userRepository.UserRepository.GetUser(username, trackChanges: false);

            if (user == null)
            {
                _logger.Info("Client tried to query user=null or invalid username syntax");
                return NotFound("User doesnt exist or Invalid username-syntax");
            }

            user = _userRepository.UserRepository.PopulateRatingsLists(user);
            var usersTotalRating = RatingExtensionHelpers.AverageRating(user.MyRatings);
            var userComments = _repositoryManager.Comment.GetCommentsByUserId(false, user.UserId);

            var usersTotalRealEstates = user.RealEstates.Count();

            var usersTotalComments = userComments.Count();

            user.AverageRating = usersTotalRating;
            user.TotalRealEstates = usersTotalRealEstates;
            user.TotalComments = usersTotalComments;

            var userEntity = _mapper.Map<UserDto>(user);

            if (user == null)
            {
                _logger.Error("User attempted to retrieve is null.");
                return NotFound("User doesnt exist");
            }
            else
            {
                return Ok(userEntity);
            }
        }

        /// <summary>
        /// Create/Post a rating about a User, requires Login.
        /// </summary>
        /// <remarks>
        /// Create/Post a new Rating about a User.
        /// 
        /// This requires you to be logged in to use.
        /// 
        /// Must provide an existing user's Id in {userId} to use.
        /// 
        ///     Post/rate
        ///     {
        ///         "userId" : "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        ///         "value" : "Går att lita på. Låga priser, bra deals."
        ///     }
        ///     
        /// </remarks>
        /// <param name="ratingDto"></param>
        /// <returns></returns>
        [HttpPut("rate")]
        [Authorize]
        public IActionResult Rate([FromBody] RatingDto ratingDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.Error($"Invalid modelstate of: {ModelState}");
                return UnprocessableEntity(ModelState);
            }

            var ratingParse = int.Parse(ratingDto.Value);
            var user = _userRepository.UserRepository.GetUserByGuid(ratingDto.UserId, false);
            var getLoggedInUsername = HttpContext.User.Identity.Name.ToString();
            var userLoggedIn = _userRepository.UserRepository.GetUser(getLoggedInUsername, false);

            if(user == null)
            {
                _logger.Error("user is null");
                return NotFound("User is null");
            }

            UserRatingDto userRatingDto = new UserRatingDto
            {
                GetUserById = userLoggedIn.UserId,
                AboutId = user.UserId,
                UserId = ratingDto.UserId,
                Value = ratingDto.Value
            };

            
            user = _userRepository.UserRepository.PopulateRatingsLists(user);

            if (user.UserName == userLoggedIn.UserName)
            {
                _logger.Error("User tried to rate themself, this is illegal.");
                return BadRequest("User cannot rate themself.");
            }

            if (user.UserName != userLoggedIn.UserName)
            {
                var notMultipleRatings = RatingExtensionHelpers.CheckMultipleRatingsFromUserAsync(user, userRatingDto);

                if (notMultipleRatings == false)
                {
                    var rating = new Rating
                    {
                        WrittenByUserId = userRatingDto.UserId.ToString(),
                        UserToWriteAboutId = userRatingDto.AboutId,
                        UserToWriteAbout = user,
                        WrittenByUser = userLoggedIn,
                        Value = ratingParse,
                    };

                    _mapper.Map(userRatingDto, rating);
                    user.MyRatings.Add(rating);
                    userLoggedIn.RatingsDoneByMe.Add(rating);
                    _userRepository.UserRepository.UpdateUser(user);
                    _userRepository.UserRepository.UpdateUser(userLoggedIn);
                    _userRepository.Save();
                    return Ok();
                }
                if (notMultipleRatings == true)
                {
                    _logger.Error($"User:{userLoggedIn.UserName} , tried to rate the same user:{user.UserName} , more than once.");
                    return BadRequest("You have already rated this user.");
                }
                else
                {
                    _logger.Error($"User:{userLoggedIn.UserName} , tried to rate the same user:{user.UserName} , more than once.");
                    return BadRequest("You have already rated this user.");
                }
            }
            else
            {
                _logger.Warning("The user you are trying to update is not logged in, please log in before you continiue.");
                return BadRequest("Wrong User logged in, result: Unauthorized.");
            }
        }
    }
}
