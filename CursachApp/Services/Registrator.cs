using CursachApp.Infrastructure.Repositories;
using CursachApp.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursachApp.Services
{
    internal static class Registrator
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer("Server=tenebrepc;Database=schelduleDb;Integrated Security=True;"));

            return services;
        }
    }
}
