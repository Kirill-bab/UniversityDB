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
    public class DatabaseFacultyService : DatabaseAdminService<Faculty>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Student> _studentRepository;
        public DatabaseFacultyService(
            IMapper mapper,
            IRepository<Faculty> repository,
            IRepository<Student> studentRepository,
            ILoggerFactory loggerFactory) : base(repository, loggerFactory)
        {
            _mapper = mapper;
            _studentRepository = studentRepository;
        }

        public async Task<IEnumerable<Faculty>> GetFaculties(CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync(cancellationToken);
        }

        public async Task<Faculty> GetFaculty(int id, CancellationToken cancellationToken)
        {
            return await _repository.GetAsync(id, cancellationToken);
        }

        //public async Task AddFaculties(IEnumerable<FacultyDTO> facultyDTOs,
        //    IRepository<Faculty> facultyRepository,
        //    CancellationToken cancellationToken)
        //{
        //    foreach (GroupDTO g in groupDTOs)
        //    {
        //        await ValidateGroup(g, facultyRepository, cancellationToken);
        //    }

        //    await AddRange(_mapper.Map<IEnumerable<Group>>(groupDTOs), cancellationToken);
        //}
        public async Task AddFaculty(FacultyDTO facultyDTO,
            CancellationToken cancellationToken)
        {
            await ValidateFaculty(facultyDTO, cancellationToken);
            await Add( _mapper.Map<Faculty>(facultyDTO), cancellationToken);
        }
        public async Task UpdateFaculty(FacultyDTO facultyDTO,
            CancellationToken cancellationToken)
        {
            await ValidateFaculty(facultyDTO, cancellationToken);
            await Update(_mapper.Map<Faculty>(facultyDTO), cancellationToken);
        }
        public async Task DeleteFaculty(int id, CancellationToken cancellationToken, 
            IRepository<Group> groupRepository)
        {
            if (!(await _repository.GetAllAsync(cancellationToken)).Select(p => p.Id).Contains(id)) throw new KeyNotFoundException("Id");
            var faculty = await GetFaculty(id, cancellationToken);
            foreach(Student s in (await _studentRepository.GetAllAsync(cancellationToken))
                .Where(p => faculty.Cafedras.Contains(p.Cafedra)))
            {
                s.Cafedra = null;
            }

            foreach (var group in (await groupRepository.GetAllAsync(cancellationToken))
                .Where(g => faculty.Cafedras.Contains(g.Cafedra)))
            {
                group.Cafedra = null;
            }

            await Delete(id, cancellationToken);
        }

        private async Task ValidateFaculty(FacultyDTO facultyDTO,
            CancellationToken cancellationToken)
        {
            var faculties = await _repository.GetAllAsync(cancellationToken);
            if (faculties.Select(p => p.Id).Contains(facultyDTO.Id) || faculties.Select(g => g.Name).Contains(facultyDTO.Name))
                throw new DuplicateException(facultyDTO.Name);
        }
    }
}
