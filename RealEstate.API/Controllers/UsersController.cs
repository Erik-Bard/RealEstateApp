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

        public UsersController(ILoggerManager logger,
            IMapper mapper,
            IUserManagerRepository userRepository)
        {
            this._mapper = mapper;
            this._logger = logger;
            this._userRepository = userRepository;
        }

        // Add Get Total Real Estates to retrieved User,
        // add total comments,
        // add Calculate Average Rating for this User
        [HttpGet("{username}")]
        [AllowAnonymous]
        public IActionResult GetUsers(string username)
        {
            var user = _userRepository.UserRepository.GetUser(username, trackChanges: false);
            if (user == null)
            {
                return BadRequest("User doesnt exist.");
            }
            user = _userRepository.UserRepository.PopulateRatingsLists(user);
            var usersTotalRating = RatingExtensionHelpers.AverageRating(user.MyRatings);

            var usersTotalRealEstates = user.RealEstates.Count();

            //var usersTotalComments = user.TotalComments.Count();

            user.AverageRating = usersTotalRating;
            user.TotalRealEstates = usersTotalRealEstates;
            //user.TotalComments = usersTotalComments;

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

        [HttpPut("rate")]
        [Authorize]
        public IActionResult Rate([FromBody] RatingDto ratingDto)
        {
            var ratingParse = int.Parse(ratingDto.Value);
            var user = _userRepository.UserRepository.GetUserByGuid(ratingDto.UserId, false);
            var getLoggedInUsername = HttpContext.User.Identity.Name.ToString();
            var userLoggedIn = _userRepository.UserRepository.GetUser(getLoggedInUsername, false);

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
