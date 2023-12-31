﻿using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Entities.Identity;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturn>()
                .ForMember(d => d.ProductBrand ,o=> o.MapFrom(s=>s.ProductBrand.Name))
                .ForMember(d => d.productType, o => o.MapFrom(s => s.productType.Name))
                .ForMember(d=>d.PictureUrl, o=>o.MapFrom<ProductUrlResolve>());

            CreateMap<Adddress, AddressDto>().ReverseMap();

        }
    }
}
