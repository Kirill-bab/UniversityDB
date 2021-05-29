using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UniversityDB.BLL.DTO;
using UniversityDB.DAL.Entities;
using UniversityDB.DAL.Repositories;

namespace UniversityDB.BLL.Mappings
{
    public class CustomMapper
    {
        private readonly IRepository<Group> _groupRepository;

        public CustomMapper(IRepository<Group> groupRepository)
        {
            _groupRepository = groupRepository;
        }
        public async Task<Student> MapStudentAsync(StudentDTO studentDTO, CancellationToken cancellationToken)
        {
            var group = (await _groupRepository.GetAllAsync(cancellationToken))
                .FirstOrDefault(g => g.GroupCode == studentDTO.GroupName);

            return new Student()
            {
                StudentId = studentDTO.Id,
                FirstName = studentDTO.FirstName,
                LastName = studentDTO.LastName,
                Age = studentDTO.Age,
                Sex = studentDTO.Sex,
                HasChildren = studentDTO.HasChildren,
                ScholarshipAmount = studentDTO.ScholarshipAmount,
                EnrolmentDate = studentDTO.EnrolmentDate,
                GroupId = group.GroupId,
                //Group = group,
                Cafedra = studentDTO.Cafedra,
                Semestr = studentDTO.Semestr
            };
        }

        public async Task<IEnumerable<Student>> MapStudentsAsync(IEnumerable<StudentDTO> studentDTOs, CancellationToken cancellationToken)
        {
            var students = new List<Student>(studentDTOs.Count());
            foreach(var student in studentDTOs)
            {
                students.Add(await MapStudentAsync(student, cancellationToken));
            }
            return students;
        }
    }
}
