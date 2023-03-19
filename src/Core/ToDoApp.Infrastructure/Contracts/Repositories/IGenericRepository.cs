using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.Dto;

namespace ToDoApp.Application.Contracts.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<T> Get(int id);
        Task<List<T>> All();
    }
}
