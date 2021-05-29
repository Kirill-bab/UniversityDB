using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UniversityDB.BLL.DTO;
using UniversityDB.BLL.DTO.TeacherRanksDTO;
using UniversityDB.DAL.Entities;
using UniversityDB.DAL.Entities.TeachersRanks;
using UniversityDB.DAL.Repositories;
using System.Linq;
using UniversityDB.BLL.Exceptions;
using UniversityDB.BLL.Mappings;

namespace UniversityDB.BLL.Services
{
    public class DatabaseTeacherService : DatabaseAdminService<Teacher>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Faculty> _facultyRepository;
        public DatabaseTeacherService(
            IMapper mapper,
            IRepository<Teacher> repository,
            IRepository<Faculty> facultyRepository,
            ILoggerFactory loggerFactory) : base(repository, loggerFactory)
        {
            _mapper = mapper;
            _facultyRepository = facultyRepository;
        }

        public async Task<IEnumerable<Teacher>> GetTeachers(CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync(cancellationToken);
        }

        public async Task<Teacher> GetTeacher(int id, CancellationToken cancellationToken)
        {
            var teacher = await _repository.GetAsync(id, cancellationToken);
            return teacher;
        }

        public async Task AddTeacher(TeacherDTO teacherDTO,
            CancellationToken cancellationToken)
        {
            await ValidateTeacher(teacherDTO, cancellationToken);
            await Add(_mapper.Map<Teacher>(teacherDTO), cancellationToken);
        }
        public async Task UpdateTeacher(TeacherDTO teacherDTO,
            CancellationToken cancellationToken)
        {
            await ValidateTeacher(teacherDTO, cancellationToken);
            await Update(_mapper.Map<Teacher>(teacherDTO), cancellationToken);
        }
        public async Task DeleteTeacher(int id, CancellationToken cancellationToken)
        {
            if (!(await _repository.GetAllAsync(cancellationToken)).Select(p => p.Id).Contains(id)) throw new KeyNotFoundException("Id");
            //delete in shedule

            await Delete(id, cancellationToken);
        }

        private async Task ValidateTeacher(TeacherDTO teacherDTO,
            CancellationToken cancellationToken)
        {
            if ((await _repository.GetAllAsync(cancellationToken)).Select(p => p.Id).Contains(teacherDTO.Id)) 
                throw new DuplicateException(teacherDTO.FirstName + " " + teacherDTO.LastName);

            var cafedraList = (await _facultyRepository.GetAllAsync(cancellationToken)).Select(f => f.Cafedras);
            foreach(List<string> cafedra in cafedraList)
            {
                if (!cafedra.Contains(teacherDTO.Cafedra)) throw new CafedraNotFoundException(teacherDTO.Cafedra);
            }
        }
    }
}
