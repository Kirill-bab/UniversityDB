using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UniversityDB.BLL.DTO;
using UniversityDB.BLL.Exceptions;
using UniversityDB.DAL.Entities;
using UniversityDB.DAL.Repositories;

namespace UniversityDB.BLL.Services
{
    public class DatabaseDisciplineService : DatabaseAdminService<Discipline>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Faculty> _facultyRepository;
        public DatabaseDisciplineService(
            IMapper mapper,
            IRepository<Discipline> repository,
            IRepository<Faculty> facultyRepository,
            ILoggerFactory loggerFactory) : base(repository, loggerFactory)
        {
            _mapper = mapper;
            _facultyRepository = facultyRepository;
        }

        public async Task<IEnumerable<Discipline>> GetDisciplines(CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync(cancellationToken);
        }

        public async Task<Discipline> GetDiscipline(int id, CancellationToken cancellationToken)
        {
            return await _repository.GetAsync(id, cancellationToken);
        }

        public async Task AddGDiscipline(DisciplineDTO disciplineDTO,
            CancellationToken cancellationToken)
        {
            await ValidateDiscipline(disciplineDTO, cancellationToken);
            await Add( _mapper.Map<Discipline>(disciplineDTO), cancellationToken);
        }
        public async Task UpdateDiscipline(DisciplineDTO disciplineDTO,
            CancellationToken cancellationToken)
        {
            await ValidateDiscipline(disciplineDTO, cancellationToken);
            await Update(_mapper.Map<Discipline>(disciplineDTO), cancellationToken);
        }
        public async Task DeleteDiscipline(int id, CancellationToken cancellationToken)
        {
            if (!(await _repository.GetAllAsync(cancellationToken)).Select(p => p.Id).Contains(id)) throw new KeyNotFoundException("Id");
            //add schedule item delete

            await Delete(id, cancellationToken);
        }

        private async Task ValidateDiscipline(DisciplineDTO disciplineDTO,
            CancellationToken cancellationToken)
        {
            var disciplines = await _repository.GetAllAsync(cancellationToken);
            if (disciplines.Select(d => d.Id).Contains(disciplineDTO.Id) || disciplines.Select(g => g.Name).Contains(disciplineDTO.Name))
                throw new DuplicateException(disciplineDTO.Name);

            var cafedraList = (await _facultyRepository.GetAllAsync(cancellationToken)).Select(f => f.Cafedras);
            foreach (string cafedra in disciplineDTO.Cafedras)
            {
                var isFound = false; 
                foreach (var caf in cafedraList)
                {
                    if (caf.Contains(cafedra)) isFound = true;
                }
                if (!isFound) throw new CafedraNotFoundException(cafedra);
            }
        }
    }
}
