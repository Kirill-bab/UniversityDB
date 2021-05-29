using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UniversityDB.BLL.DTO;
using UniversityDB.BLL.DTO.TeacherRanksDTO;
using UniversityDB.BLL.Services;
using UniversityDB.DAL.Entities;
using UniversityDB.DAL.Entities.TeachersRanks;
using UniversityDB.DAL.Repositories;
using UniversityDB.Web.RequestModels;
using UniversityDB.Web.RequestModels.TeacherRanksRequestModels;

namespace UniversityDB.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[TypeFilter(typeof(ExceptionFilter))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class TeacherController : ControllerBase
    {
        private readonly DatabaseTeacherService _teacherService;
        private readonly IMapper _mapper;

        public TeacherController(
            DatabaseTeacherService teacherService,
            IMapper mapper)
        {
            _teacherService = teacherService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("get/all/teachers")]
        public async Task<ActionResult<IEnumerable<Teacher>>> GetTeachers(CancellationToken cancellationToken)
        {
            var students = await _teacherService.GetTeachers(cancellationToken);
            return Ok(students);
        }

        [HttpGet]
        [Route("get/teacher/{id}")]
        public async Task<ActionResult<Teacher>> GetTeacher(
            [FromRoute] int id, CancellationToken cancellationToken)
        {
            return Ok(await _teacherService.GetTeacher(id, cancellationToken));
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
        [Route("add/teacher")]
        public async Task<IActionResult> AddTeacher(
            [FromBody] TeacherRM teacher,
            CancellationToken cancellationToken)
        {
            var teacherDTO = _mapper.Map<TeacherDTO>(teacher);
            await _teacherService.AddTeacher(teacherDTO, cancellationToken);
            return Ok();
        }
        [HttpPost]
        [Route("add/assistant")]
        public async Task<IActionResult> AddAssistant(
            [FromBody] AssistantRM teacher,
            CancellationToken cancellationToken)
        {
            var teacherDTO = _mapper.Map<AssistantDTO>(teacher);
            await _teacherService.AddTeacher(teacherDTO, cancellationToken);
            return Ok();
        }
        [HttpPost]
        [Route("add/seniorteacher")]
        public async Task<IActionResult> AddSeniorTeacher(
            [FromBody] SeniorTeacherRM teacher,
            CancellationToken cancellationToken)
        {
            var teacherDTO = _mapper.Map<SeniorTeacherDTO>(teacher);
            await _teacherService.AddTeacher(teacherDTO, cancellationToken);
            return Ok();
        }
        [HttpPost]
        [Route("add/docent")]
        public async Task<IActionResult> AddDocent(
            [FromBody] DocentRM teacher,
            CancellationToken cancellationToken)
        {
            var teacherDTO = _mapper.Map<DocentDTO>(teacher);
            await _teacherService.AddTeacher(teacherDTO, cancellationToken);
            return Ok();
        }
        [HttpPost]
        [Route("add/proffesor")]
        public async Task<IActionResult> AddProffesor(
            [FromBody] TeacherRM teacher,
            CancellationToken cancellationToken)
        {
            var teacherDTO = _mapper.Map<ProffesorDTO>(teacher);
            await _teacherService.AddTeacher(teacherDTO, cancellationToken);
            return Ok();
        }

        [HttpPost]
        [Route("update/teacher")]
        public async Task<IActionResult> UpdateTeacher(
            [FromBody] TeacherRM teacher,
            CancellationToken cancellationToken)
        {
            var teacherDTO = _mapper.Map<TeacherDTO>(teacher);
            await _teacherService.UpdateTeacher(teacherDTO, cancellationToken);
            return Ok();
        }

        [HttpDelete]
        [Route("delete/teacher/{id}")]
        public async Task<IActionResult> DeleteTeacher(
            [FromRoute] int id,
            CancellationToken cancellationToken)
        {
            await _teacherService.DeleteTeacher(id, cancellationToken);
            return Ok();
        }
    }
}
