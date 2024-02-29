using AutoMapper;
using ListaTarefa.Domain.Entities;
using ListaTarefa.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaTarefa.Domain.DTOs.Mapping
{
    public class TarefaMappingDTO : Profile
    {
        public TarefaMappingDTO()
        {
            CreateMap<Tarefa, TarefaDTO>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => (int)src.Status));
            CreateMap<TarefaDTO, Tarefa>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => (StatusTarefa)src.Status));
        }
    }
}
