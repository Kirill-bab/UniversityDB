using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UniversityDB.DAL.Repositories;

namespace UniversityDB.BLL.Services
{
    public abstract class DatabaseAdminService<T> where T : class
    {
        protected readonly IRepository<T> _repository;
        private readonly ILogger _logger;

        public DatabaseAdminService(
            IRepository<T> repository,
            ILoggerFactory loggerFactory)
        {
            _repository = repository;
            _logger = loggerFactory.CreateLogger<DatabaseAdminService<T>>();
        }

        public async Task AddRange(IEnumerable<T> objects, CancellationToken cancellationToken)
        {
            await _repository.AddRangeAsync(objects, cancellationToken);
            _logger.LogInformation($"Entities of type {typeof(T).Name} were added to database");
        }
        public async Task Add(T @object, CancellationToken cancellationToken)
        {
            await _repository.AddAsync(@object, cancellationToken);
            _logger.LogInformation($"Entitiy of type {typeof(T).Name} was added to database");
        }
        public async Task Update(T @object, CancellationToken cancellationToken)
        {
            await _repository.UpdateAsync(@object, cancellationToken);
            _logger.LogInformation($"Entity of type {typeof(T).Name} was updated");
        }
        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            var @object = await _repository.GetAsync(id, cancellationToken);
            await _repository.DeleteAsync(@object, cancellationToken);
            _logger.LogInformation($"Entity of type {typeof(T).Name} with id {id} was deleted from database");
        }
    }
}
