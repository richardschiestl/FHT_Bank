using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using FHT_Bank.Domain.Dtos;
using FHT_Bank.Domain.Models;

namespace FHT_Bank.Domain.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AccountDto, Account>().ReverseMap();
        }
    }
}
