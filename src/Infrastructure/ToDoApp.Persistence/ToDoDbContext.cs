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
                ToDoItemName = "MyFirstTodo",
                ToDoIsDone = false,
            });
            modelBuilder.Entity<ToDoItem>().HasData(new ToDoItem
            {
                ToDoItemId = 2,
                ToDoItemName = "MySecondTodo",
                ToDoIsDone = false,
            });
            modelBuilder.Entity<ToDoItem>().HasData(new ToDoItem
            {
                ToDoItemId = 3,
                ToDoItemName = "MyThirdTodo",
                ToDoIsDone = false,
            });
            modelBuilder.Entity<ToDoItem>().HasData(new ToDoItem
            {
                ToDoItemId = 4,
                ToDoItemName = "MyFourthTodo",
                ToDoIsDone = false,
            });
        }

        //protected readonly IConfiguration Configuration;
        //public ToDoDbContext(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}

            //protected override void OnConfiguring(DbContextOptionsBuilder options)
            //{
            //    // in memory database used for simplicity, change to a real db for production applications
            //    options.UseInMemoryDatabase("ToDoInMem");
            //}

        public DbSet<ToDoItem> ToDoItems { get; set; }
        //public DbSet<ToDoList> ToDoLists { get; set; }

    }
}
