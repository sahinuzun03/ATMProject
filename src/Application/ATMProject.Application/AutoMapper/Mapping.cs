using ATMProject.Application.Models.DTOs;
using ATMProject.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject.Application.AutoMapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<User, LoginDTO>().ReverseMap();
            CreateMap<UserProcess, ProcessDTO>().ReverseMap();
        }

    }
}
