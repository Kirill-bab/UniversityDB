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
    public class DatabaseStudentService : DatabaseAdminService<Student>
    {
        private readonly CustomMapper _studentMapper;
        private readonly IRepository<Group> _groupRepository;
        private readonly IRepository<Faculty> _facultyRepository;
        public DatabaseStudentService(
            CustomMapper studentMapper,
            IRepository<Student> repository,
            IRepository<Group> groupRepository,
            IRepository<Faculty> facultyRepository,
            ILoggerFactory loggerFactory) : base(repository, loggerFactory)
        {
            _studentMapper = studentMapper;
            _facultyRepository = facultyRepository;
            _groupRepository = groupRepository;
        }

        public async Task<IEnumerable<Student>> GetStudents(CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync(cancellationToken);
        }

        public async Task<Student> GetStudent(int id, CancellationToken cancellationToken)
        {
            var student = await _repository.GetAsync(id, cancellationToken);
            student.Group = await _groupRepository.GetAsync(student.GroupId, cancellationToken);
            return student;
        }

        public async Task AddStudents(IEnumerable<StudentDTO> studentDTOs,
            CancellationToken cancellationToken)
        {
            foreach (StudentDTO s in studentDTOs)
            {
                await ValidateStudent(s, _groupRepository, _facultyRepository, cancellationToken);
            }

            await AddRange(await _studentMapper.MapStudentsAsync(studentDTOs, cancellationToken), cancellationToken);
        }
        public async Task AddStudent(StudentDTO studentDTO,
            CancellationToken cancellationToken)
        {
            await ValidateStudent(studentDTO, _groupRepository, _facultyRepository, cancellationToken);
            await Add(await _studentMapper.MapStudentAsync(studentDTO, cancellationToken), cancellationToken);
        }
        public async Task UpdateStudent(StudentDTO studentDTO,
            CancellationToken cancellationToken)
        {
            await ValidateStudent(studentDTO, _groupRepository, _facultyRepository, cancellationToken);
            await Update(await _studentMapper.MapStudentAsync(studentDTO, cancellationToken), cancellationToken);
        }
        public async Task DeleteStudent(int id, CancellationToken cancellationToken)
        {
            if (!(await _repository.GetAllAsync(cancellationToken)).Select(p => p.GroupId).Contains(id)) throw new KeyNotFoundException("Id");

            await Delete(id, cancellationToken);
        }

        public async Task<IEnumerable<Student>> ParametrisedSearch(string Group,
             int? Course,
             string Faculty,
             Sex? Sex,
             int? Age,
             bool? Children,
             decimal? Scholarship,
             CancellationToken cancellationToken)
            {
            var students = await _repository.GetAllAsync(cancellationToken);
            students = Course is null ? students : students.Where(s => Math.Ceiling((decimal)s.Semestr / 2) == Course);
            var faculties = await _facultyRepository.GetAllAsync(cancellationToken);
            students = Faculty is null ? students : students.Where(s => faculties.Select(f=>f.Name).Contains(Faculty));
            students = Sex is null ? students : students.Where(s => s.Sex == Sex);
            students = Age is null ? students : students.Where(s => s.Age == Age);
            students = Children is null ? students : students.Where(s => s.HasChildren == Children);
            students = Scholarship is null ? students : students.Where(s => s.ScholarshipAmount == Scholarship);

            return students;
        }

        private async Task ValidateStudent(StudentDTO studentDTO, 
            IRepository<Group> groupRepository, 
            IRepository<Faculty> facultyRepository,
            CancellationToken cancellationToken)
        {
            if ((await _repository.GetAllAsync(cancellationToken)).Select(p => p.GroupId).Contains(studentDTO.Id)) 
                throw new DuplicateException(studentDTO.FirstName + " " + studentDTO.LastName);

            if (!(await groupRepository.GetAllAsync(cancellationToken)).Select(g => g.GroupCode).Contains(studentDTO.GroupName))
                throw new GroupNotFoundException(studentDTO.GroupName);

            var cafedraList = (await facultyRepository.GetAllAsync(cancellationToken)).Select(f => f.Cafedras);
            foreach(List<string> cafedra in cafedraList)
            {
                if (!cafedra.Contains(studentDTO.Cafedra)) throw new CafedraNotFoundException(studentDTO.Cafedra);
            }
        }
    }
}
