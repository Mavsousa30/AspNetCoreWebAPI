using AutoMapper;
using SmartSchool.API.Dtos;
using SmartSchool.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.API.Helpers
{
    public class SmartSchoolProfile : Profile
    {
        public SmartSchoolProfile()
        {
            CreateMap<Aluno, AlunoDto>().
                ForMember(
                dest => dest.Nome,
                opt => opt.MapFrom(src => $"{src.Nome} {src.Sobrenome}")
                )
                .ForMember(
                dest => dest.Idade,
                opt => opt.MapFrom(src => src.DataNascimento.GetCurrentAge())
                );

            CreateMap<AlunoDto, Aluno>();

            CreateMap<Aluno, AlunoRegistrarDto>().ReverseMap();
        }
    }
}
