using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FullWeb.Models;
using FullWeb.Dtos;

namespace FullWeb.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        { 

            CreateMap<Donation, DonationDto>();
            CreateMap<Product, ProductDto>();
            CreateMap<Project, ProjectDto>();
            CreateMap<Volunteer, VolunteerDto>();

            CreateMap<DonationDto, Donation>()
                .ForMember(c => c.Id, opt => opt.Ignore());

            CreateMap<ProjectDto, Project>()
                .ForMember(c => c.Id, opt => opt.Ignore());

            CreateMap<ProductDto, Product>()
                .ForMember(c => c.Id, opt => opt.Ignore());

            CreateMap<VolunteerDto, Volunteer>()
                .ForMember(c => c.Id, opt => opt.Ignore());

        }
    }
}
