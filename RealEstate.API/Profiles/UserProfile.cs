using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using IdentityLibrary.Authentication;
using IdentityLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.API.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(dest =>
                    dest.Username,
                        opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest =>
                    dest.Rating,
                        opt => opt.MapFrom(src => src.AverageRating))
                .ForMember(dest =>
                    dest.Comments,
                        opt => opt.MapFrom(src => src.TotalComments))
                .ForMember(dest =>
                    dest.RealEstates,
                        opt => opt.MapFrom(src => src.TotalRealEstates))
                .ReverseMap();

            CreateMap<UserRatingDto, Rating>()
                .ForMember(dest =>
                    dest.Value,
                    opt => opt.MapFrom(src => src.Value))
                .ForMember(dest =>
                    dest.UserToWriteAboutId,
                    opt => opt.MapFrom(src => src.AboutId))
                .ForMember(dest =>
                    dest.WrittenByUserId,
                    opt => opt.MapFrom(src => src.GetUserById));

            CreateMap<UserRatingDto, RatingDto>()
                .ForMember(dest =>
                    dest.UserId,
                    opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest =>
                    dest.Value,
                    opt => opt.MapFrom(src => src.Value));

            CreateMap<ApplicationUser, User>()
                .ForMember(dest =>
                    dest.UserId,
                        opt => opt.MapFrom(src => src.Id))
                .ForMember(dest =>
                    dest.UserName,
                        opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest =>
                    dest.Email,
                        opt => opt.MapFrom(src => src.Email));

        }
    }
}
