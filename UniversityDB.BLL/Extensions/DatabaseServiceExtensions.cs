using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using UniversityDB.DAL.Contexts;

namespace UniversityDB.BLL
{
    public static class DatabaseServiceExtensions
    {
        public static IServiceCollection AddDatabaseServicesInMemory(this IServiceCollection services, IConfiguration configuration)
        {
            //Add database and migration services.
            services.AddDbContext<DatabaseManagerContext>(
                options => options.UseNpgsql(configuration.GetConnectionString("DatabaseManagerContext"),
                options => options.MigrationsAssembly("UniversityDB.DAL")));

            //services.AddHostedService<MigrationsService>();
            //services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            //services.AddTransient<IUserRepository, UserRepository>();

            return services;
        }
    }
}
