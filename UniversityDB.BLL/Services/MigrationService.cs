using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UniversityDB.DAL.Contexts;

namespace UniversityDB.BLL.Services
{
    public class MigrationsService : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;

        public MigrationsService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var scope = _serviceProvider.CreateScope();
            await using var databaseManagerContext = scope.ServiceProvider.GetRequiredService<DatabaseManagerContext>();

            await databaseManagerContext.Database.MigrateAsync(cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
