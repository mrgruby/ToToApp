using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.Contracts.Repositories;
using ToDoApp.Domain.Entities;

namespace ToDoApp.Persistence.Implementation.Repositories
{
    public class ToDoRepository : GenericRepository<ToDoItem>, IToDoRepository
    {
        private readonly ToDoDbContext _dbContext;

        public ToDoRepository(ToDoDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
