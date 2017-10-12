using AutoMapper;
using MovieRentalSite.Dtos;
using MovieRentalSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieRentalSite.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // calling createMap - automapper uses reflection to scan these types, finds
            // their properties and maps them based on their name
            Mapper.CreateMap<Customer, CustomerDto>().ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<CustomerDto, Customer>();

            Mapper.CreateMap<Movie, MovieDto>().ForMember(m => m.Id, opt => opt.Ignore());
            Mapper.CreateMap<MovieDto, Movie>();  
        }
    }
}