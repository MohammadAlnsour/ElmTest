using ElmTest.Infrastructure.Dapper;
using ElmTest.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElmTest.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDbServices(this IServiceCollection services)
        {
            services.AddScoped<IBookDbService, BookDbService>();
            services.AddScoped<IBookRepository, BookRepository>();
            return services;
        }
    }
}
