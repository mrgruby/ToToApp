using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.Dto;
using ToDoApp.Domain.Entities;

namespace ToDoApp.Application.MappingProfiles
{
    public class ToDoMappingProfiles : Profile
    {
        public ToDoMappingProfiles()
        {
            CreateMap<ToDoItem, ToDoItemDto>().ReverseMap();
        }
    }
}
