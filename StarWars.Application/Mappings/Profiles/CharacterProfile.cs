using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using StarWars.Application.DTOs;
using StarWars.Domain.Entities;

namespace StarWars.Application.Mappings.Profiles
{
    public class CharacterProfile : Profile
    {
        public CharacterProfile()
        {
            CreateMap<Character, CharacterDto>()
                .ForMember(c => c.Friends, opt => opt.MapFrom(src => src.Friends.Select(f => f.Name)));
        }
    }
}