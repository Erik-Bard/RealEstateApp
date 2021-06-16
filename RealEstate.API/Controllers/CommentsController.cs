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
            private readonly IMapper _mapper;
            private readonly ILoggerManager _logger;

            public CommentController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
            {
                this._repositoryAccess = repository;
                this._mapper = mapper;
                this._logger = logger;
            }

            [HttpGet("ByRealEstate")]
            [AllowAnonymous]
            public IActionResult RetriveCommentsByRealEstate(Guid id, int skip, int take)
            {
                var comments = _repositoryAccess.Comment.GetAllComments(false);

                var returnList = comments.Where(e => e.AdvertismentId == id);

                return Ok(returnList);

            }


            /* [HttpPost]
             public IActionResult CreateComment(Comment comment)
             {


             }


             [HttpGet("ByUser")]
             [AllowAnonymous]
             public IActionResult RetriveCommentsSkipTakeByUser(int skip, int take)
             {



             }

             [HttpGet("SkipTake")]
             [AllowAnonymous]
             public IActionResult RetrieveCommentsSkipTake(int skip, int take)
             {


             }
            */       

    }
}
