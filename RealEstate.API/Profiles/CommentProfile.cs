using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.API.Profiles
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<CommentCreationDto, Comment>();
            CreateMap<Comment, CommentResponseDto>()
                .ForMember(dest =>
                    dest.Content,
                        opt => opt.MapFrom(c => c.Content))
                .ForMember(dest =>
                    dest.CreatedOn,
                        opt => opt.MapFrom(c => c.CreatedOn));
        }
    }
}
