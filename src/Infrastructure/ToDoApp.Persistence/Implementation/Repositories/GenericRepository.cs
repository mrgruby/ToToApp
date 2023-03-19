using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.Contracts.Repositories;
using ToDoApp.Application.Dto;

namespace ToDoApp.Persistence.Implementation.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ToDoDbContext _context;

        public GenericRepository(ToDoDbContext context)
        {
            _context = context;
        }
        public async Task<T> Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<List<T>> All()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChangesAsync();
        }

        public async Task<T> Get(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChangesAsync();
        }
    }
}
