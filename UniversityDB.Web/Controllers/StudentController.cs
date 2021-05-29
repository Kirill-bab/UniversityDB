using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UniversityDB.BLL.DTO;
using UniversityDB.BLL.Services;
using UniversityDB.DAL.Entities;
using UniversityDB.DAL.Repositories;
using UniversityDB.Web.RequestModels;

namespace UniversityDB.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[TypeFilter(typeof(ExceptionFilter))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class StudentController : ControllerBase
    {
        private readonly DatabaseStudentService _studentService;
        private readonly IMapper _mapper;

        public StudentController(
            DatabaseStudentService studentService,
            IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("get/all/students")]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents(CancellationToken cancellationToken)
        {
            var students = await _studentService.GetStudents(cancellationToken);
            return Ok(students);
        }

        [HttpGet]
        [Route("get/student/{id}")]
        public async Task<ActionResult<Student>> GetStudent(
            [FromRoute] int id, CancellationToken cancellationToken)
        {
            return Ok(await _studentService.GetStudent(id, cancellationToken));
        }

        //[HttpPost]
        //[Route("add/students")]
        //public async Task<IActionResult> AddStudents(
        //    [FromBody] IEnumerable<StudentRM> students,
        //    [FromServices] IRepository<Group> groupRepository,
        //    [FromServices] IRepository<Faculty> facultyRepository,
        //    CancellationToken cancellationToken)
        //{
        //    var studentsDTO = _mapper.Map<IEnumerable<StudentDTO>>(students);
        //    await _studentService.AddStudents(studentsDTO, cancellationToken);
        //    return Ok();
        //}

        [HttpPost]
        [Route("add/student")]
        public async Task<IActionResult> AddStudent(
            [FromServices] IRepository<Group> groupRepository,
            [FromServices] IRepository<Faculty> facultyRepository,
            [FromBody] StudentRM student,
            CancellationToken cancellationToken)
        {
            var studentDTO = _mapper.Map<StudentDTO>(student);
            await _studentService.AddStudent(studentDTO, cancellationToken);
            return Ok();
        }

        [HttpPut]
        [Route("update/student")]
        public async Task<IActionResult> UpdateStudent(
            [FromBody] StudentRM student,
            [FromServices] IRepository<Group> groupRepository,
            [FromServices] IRepository<Faculty> facultyRepository,
            CancellationToken cancellationToken)
        {
            var studentDTO = _mapper.Map<StudentDTO>(student);
            await _studentService.UpdateStudent(studentDTO, cancellationToken);
            return Ok();
        }

        [HttpDelete]
        [Route("delete/student/{id}")]
        public async Task<IActionResult> DeleteSudent(
            [FromRoute] int id,
            CancellationToken cancellationToken)
        {
            await _studentService.DeleteStudent(id, cancellationToken);
            return Ok();
        }


        [HttpGet]
        [Route("get/students/by/parms")]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudentsByParms(
            [FromQuery] string Group,
            [FromQuery] int? Course,
            [FromQuery] string Faculty,
            [FromQuery] Sex? Sex,
            [FromQuery] int? Age,
            [FromQuery] bool? Children,
            [FromQuery] decimal? Scholarship,
            CancellationToken cancellationToken)
        {
            var students = await _studentService.ParametrisedSearch(
                Group, Course, Faculty, Sex, Age, Children, Scholarship, cancellationToken);
            return Ok(students);
        }
    }
}
