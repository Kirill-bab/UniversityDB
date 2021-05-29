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
    public class DisciplineController : ControllerBase
    {
        private readonly DatabaseDisciplineService _disciplineService;
        private readonly IMapper _mapper;

        public DisciplineController(
            IMapper mapper,
            DatabaseDisciplineService disciplineService)
        {
            _mapper = mapper;
            _disciplineService = disciplineService;
        }

        [HttpGet]
        [Route("get/all/disciplines")]
        public async Task<ActionResult<IEnumerable<Discipline>>> GetGroups(CancellationToken cancellationToken)
        {
            var faculties = await _disciplineService.GetDisciplines(cancellationToken);
            return Ok(faculties);
        }

        [HttpGet]
        [Route("get/faculty/{id}")]
        public async Task<ActionResult<Discipline>> GetDiscipline(
            [FromRoute] int id, CancellationToken cancellationToken)
        {
            return Ok(await _disciplineService.GetDiscipline(id, cancellationToken));
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
        [Route("add/discipline")]
        public async Task<IActionResult> AddDiscipline(
            [FromBody] DisciplineRM discipline,
            CancellationToken cancellationToken)
        {
            var disciplineDTO = _mapper.Map<DisciplineDTO>(discipline);
            await _disciplineService.AddGDiscipline(disciplineDTO, cancellationToken);
            return Ok();
        }

        [HttpPut]
        [Route("update/discipline")]
        public async Task<IActionResult> UpdateFaculty(
            [FromBody] DisciplineRM discipline,
            CancellationToken cancellationToken)
        {
            var disciplineDTO = _mapper.Map<DisciplineDTO>(discipline);
            await _disciplineService.UpdateDiscipline(disciplineDTO, cancellationToken);
            return Ok();
        }

        [HttpDelete]
        [Route("delete/discipline/{id}")]
        public async Task<IActionResult> DeleteFaculty(
            [FromRoute] int id,
            CancellationToken cancellationToken)
        {
            await _disciplineService.DeleteDiscipline(id, cancellationToken);
            return Ok();
        }
    }
}
