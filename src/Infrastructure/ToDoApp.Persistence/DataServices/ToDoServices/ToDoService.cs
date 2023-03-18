using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.Contracts.DataServices.ToDoServices;
using ToDoApp.Domain.Entities;

namespace ToDoApp.Persistence.DataServices.ToDoServices
{
    public class ToDoService : IToDoService
    {
        private readonly ToDoDbContext _context;

        public ToDoService(ToDoDbContext context)
        {
            _context = context;
        }
        public async Task<List<ToDoItem>> GetAllToDoItems()
        {
            return await _context.ToDoItems.ToListAsync();
        }
    }
}
