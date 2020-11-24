using AutoMapper;
using GameOfLifeAPI.Model;
using GameOfLifeAPI.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameOfLifeAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Cell, CellDTO>();
            CreateMap<Board, BoardDTO>();
        }
    }
}
