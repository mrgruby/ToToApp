using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.Contracts.DataServices.ToDoServices;
using ToDoApp.Application.Implementation.DataServices.ToDoServices;

namespace ToDoApp.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IToDoService, ToDoService>();

            return services;
        }
    }
}
