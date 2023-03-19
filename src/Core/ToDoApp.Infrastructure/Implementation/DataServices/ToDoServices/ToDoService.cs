using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.Contracts.DataServices.ToDoServices;
using ToDoApp.Application.Contracts.Repositories;
using ToDoApp.Application.Dto;
using ToDoApp.Application.Responses;
using ToDoApp.Domain.Entities;

namespace ToDoApp.Application.Implementation.DataServices.ToDoServices
{
    public class ToDoService : IToDoService
    {
        private readonly IToDoRepository _repository;
        private readonly IMapper _mapper;

        public ToDoService(IToDoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<ToDoItemDto>> CreateToDoItem(ToDoItemDto toDoItemDto)
        {
            var response = new ServiceResponse<ToDoItemDto>();

            var returnModel = await _repository.Add(_mapper.Map<ToDoItem>(toDoItemDto));

            if (returnModel == null)
                response.Success = false;

            if (returnModel != null && response.Success == true)
                response.Data = _mapper.Map<ToDoItemDto>(returnModel);

            return response;
        }

        public async Task<ServiceResponse<ToDoItemDto>> DeleteToDoItem(int id)
        {
            var response = new ServiceResponse<ToDoItemDto>();

            var toDoToUpdate = await _repository.Get(id);

            if (toDoToUpdate == null)
            {
                response.Success = false;
                response.Message = "ToDoItem to delete not found!";
            }

            if (toDoToUpdate != null && response.Success)
                _repository.Delete(toDoToUpdate);

            return response;
        }

        public async Task<List<ToDoItemDto>> GetAllToDoItems()
        {
            var res = await _repository.All();
            return _mapper.Map<List<ToDoItemDto>>(res);
        }

        public async Task<ToDoItemDto> GetToDoItem(int id)
        {
            var res = await _repository.Get(id);
            return _mapper.Map<ToDoItemDto>(res);
        }

        public async Task<ServiceResponse<ToDoItemDto>> UpdateToDoItem(ToDoItemDto toDoItemDto)
        {
            var response = new ServiceResponse<ToDoItemDto>();

            var toDoToUpdate = await _repository.Get(toDoItemDto.ToDoItemId);

            if (toDoToUpdate == null)
            {
                response.Success = false;
                response.Message = "ToDoItem to update not found!";
            }

            if (toDoToUpdate != null && response.Success)
            {
                _mapper.Map(toDoItemDto, toDoToUpdate);

                _repository.Update(toDoToUpdate);
            }

            return response;
        }
    }
}
