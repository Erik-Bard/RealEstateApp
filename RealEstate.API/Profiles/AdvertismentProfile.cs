using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.API.Profiles
{
    public class AdvertismentProfile : Profile
    {
        public AdvertismentProfile()
        {
            CreateMap<Advertisment, AdvertismentsDto>();
            CreateMap<AdvertismentCreationDto, Advertisment>();
            CreateMap<Advertisment, AdvertismentResponseDto>();
            CreateMap<AdvertismentCreationDto, Property>();
            CreateMap<Advertisment, AdvertisementPrivateDto>();
        }
    }
}
