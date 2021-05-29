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
    public class FacultyController : ControllerBase
    {
        private readonly DatabaseFacultyService _facultyService;
        private readonly IMapper _mapper;

        public FacultyController(
            IMapper mapper,
            DatabaseFacultyService facultyService)
        {
            _mapper = mapper;
            _facultyService = facultyService;
        }

        [HttpGet]
        [Route("get/all/faculties")]
        public async Task<ActionResult<IEnumerable<Faculty>>> GetGroups(CancellationToken cancellationToken)
        {
            var faculties = await _facultyService.GetFaculties(cancellationToken);
            return Ok(faculties);
        }

        [HttpGet]
        [Route("get/faculty/{id}")]
        public async Task<ActionResult<Faculty>> GetFaculty(
            [FromRoute] int id, CancellationToken cancellationToken)
        {
            return Ok(await _facultyService.GetFaculty(id, cancellationToken));
        }

        //[HttpPost]
        //[Route("add/groups")]
        //public async Task<IActionResult> AddStudents(
        //    [FromBody] IEnumerable<GroupRM> groups,
        //    [FromServices] IRepository<Faculty> facultyRepository,
        //    CancellationToken cancellationToken)
        //{
        //    var groupDTOs = _mapper.Map<IEnumerable<GroupDTO>>(groups);
        //    await _groupService.AddGroupss(groupDTOs, facultyRepository, cancellationToken);
        //    return Ok();
        //}

        [HttpPost]
        [Route("add/faculty")]
        public async Task<IActionResult> AddFaculty(
            [FromServices] IRepository<Faculty> facultyRepository,
            [FromBody] FacultyRM faculty,
            CancellationToken cancellationToken)
        {
            var facultyDTO = _mapper.Map<FacultyDTO>(faculty);
            await _facultyService.AddFaculty(facultyDTO, cancellationToken);
            return Ok();
        }

        [HttpPut]
        [Route("update/faculty")]
        public async Task<IActionResult> UpdateFaculty(
            [FromBody] FacultyRM faculty,
            CancellationToken cancellationToken)
        {
            var facultyDTO = _mapper.Map<FacultyDTO>(faculty);
            await _facultyService.UpdateFaculty(facultyDTO, cancellationToken);
            return Ok();
        }

        [HttpDelete]
        [Route("delete/faculty/{id}")]
        public async Task<IActionResult> DeleteFaculty(
            [FromServices] IRepository<Group> repository,
            [FromRoute] int id,
            CancellationToken cancellationToken)
        {
            await _facultyService.DeleteFaculty(id, cancellationToken, repository);
            return Ok();
        }
    }
}
