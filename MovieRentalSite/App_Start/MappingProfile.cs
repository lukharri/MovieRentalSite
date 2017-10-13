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

            // Domain to Dto
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();


            // Dto to Domain
            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<MovieDto, Movie>()
                .ForMember(m => m.Id, opt => opt.Ignore());  


        }
    }
}