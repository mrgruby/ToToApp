using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain.Entities;

namespace ToDoApp.Persistence
{
    public class ToDoDbContext : DbContext
    {
        public ToDoDbContext(DbContextOptions<ToDoDbContext> options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ToDoDbContext).Assembly);

            modelBuilder.Entity<ToDoItem>().HasData(new ToDoItem
            {
                ToDoItemId = 1,
                ToDoItemName = "First Todo",
                ToDoDescription = "First Todo description",
                ToDoIsDone = false,
            });
            modelBuilder.Entity<ToDoItem>().HasData(new ToDoItem
            {
                ToDoItemId = 2,
                ToDoItemName = "Second Todo",
                ToDoDescription = "Second Todo description",
                ToDoIsDone = false,
            });
            modelBuilder.Entity<ToDoItem>().HasData(new ToDoItem
            {
                ToDoItemId = 3,
                ToDoItemName = "Third Todo",
                ToDoDescription = "Third Todo description",
                ToDoIsDone = false,
            });
            modelBuilder.Entity<ToDoItem>().HasData(new ToDoItem
            {
                ToDoItemId = 4,
                ToDoItemName = "Fourth Todo",
                ToDoDescription = "Fourth Todo description",
                ToDoIsDone = false,
            });
        }

        public DbSet<ToDoItem> ToDoItems { get; set; }
    }
}
