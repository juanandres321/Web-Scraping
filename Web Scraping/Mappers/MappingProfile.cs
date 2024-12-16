using AutoMapper;
using System;
using Web_Scraping.DTOs;
using Web_Scraping.Models;

namespace Web_Scraping.Mappers
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<SupplierInsertDTO, Supplier>();
            CreateMap<SupplierUpdateDTO, Supplier>();
            CreateMap<Supplier, SupplierDTO>();
        }
    }
}
