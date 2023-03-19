using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.Contracts.DataServices.ToDoServices;
using ToDoApp.Application.Contracts.Repositories;
using ToDoApp.Application.Implementation.DataServices.ToDoServices;
using ToDoApp.Persistence.Implementation.Repositories;

namespace ToDoApp.Persistence
{
    /// <summary>
    /// This class extends the service collection, which is normally found in Startup.cs. Here, we add support for dependency injection. 
    /// We also add the DbContext, and specify that we will use SqlServer. Finally, the connectionstring is registered.
    /// </summary>
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ToDoDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ToDoConnectionString")));

            //Set up DI
            services.AddScoped<IToDoService, ToDoService>();
            services.AddScoped<IToDoRepository, ToDoRepository>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));


            return services;
        }
    }
}
