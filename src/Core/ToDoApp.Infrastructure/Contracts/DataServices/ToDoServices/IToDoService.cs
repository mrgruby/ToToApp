using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.Dto;
using ToDoApp.Application.Responses;
using ToDoApp.Domain.Entities;

namespace ToDoApp.Application.Contracts.DataServices.ToDoServices
{
    public interface IToDoService
    {
        Task<List<ToDoItemDto>> GetAllToDoItems();
        Task<ToDoItemDto> GetToDoItem(int id);
        Task<ServiceResponse<ToDoItemDto>>CreateToDoItem(ToDoItemDto toDoItemDto);
        Task<ServiceResponse<ToDoItemDto>> UpdateToDoItem(ToDoItemDto toDoItemDto);
        Task<ServiceResponse<ToDoItemDto>> DeleteToDoItem(int id);
    }
}