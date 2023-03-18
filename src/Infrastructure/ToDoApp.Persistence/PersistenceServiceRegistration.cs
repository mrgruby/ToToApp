using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.Contracts.DataServices.ToDoServices;
using ToDoApp.Persistence.DataServices.ToDoServices;

namespace ToDoApp.Persistence
{
    /// <summary>
    /// This class extends the service collection, which is normally found in the Startup.cs class. This class is not available here, 
    /// since this is clean architecture. This is for service registration. Here, we add support for dependency injection. We also add the DbContext, 
    /// and specify that we will use SqlServer. Finally, the connectionstring is registered.
    /// </summary>
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ToDoDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ToDoConnectionString")));

            //services.AddDbContext<ToDoDbContext>(opt => opt.UseInMemoryDatabase("ToDoInMem"));

            services.AddScoped<IToDoService, ToDoService>();
            //services.AddScoped<ToDoDbContext, ToDoDbContext>();
            

            return services;
        }
    }
}
