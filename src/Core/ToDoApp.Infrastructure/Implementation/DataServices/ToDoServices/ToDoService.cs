using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.Contracts.DataServices.ToDoServices;
using ToDoApp.Application.Contracts.Repositories;
using ToDoApp.Domain.Entities;

namespace ToDoApp.Application.Implementation.DataServices.ToDoServices
{
    public class ToDoService : IToDoService
    {
        private readonly IToDoRepository _repository;

        public ToDoService(IToDoRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<ToDoItem>> GetAllToDoItems()
        {
            return await _repository.All();
        }
    }
}
