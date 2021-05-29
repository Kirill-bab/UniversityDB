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
    public class GroupController : ControllerBase
    {
        private readonly DatabaseGroupService _groupService;
        private readonly IMapper _mapper;

        public GroupController(
            IMapper mapper,
            DatabaseGroupService groupService)
        {
            _mapper = mapper;
            _groupService = groupService;
        }

        [HttpGet]
        [Route("get/all/groups")]
        public async Task<ActionResult<IEnumerable<Group>>> GetGroups(CancellationToken cancellationToken)
        {
            var groups = await _groupService.GetGroups(cancellationToken);
            return Ok(groups);
        }

        [HttpGet]
        [Route("get/group/{id}")]
        public async Task<ActionResult<Group>> GetGroup(
            [FromRoute] int id, CancellationToken cancellationToken)
        {
            return Ok(await _groupService.GetGroup(id, cancellationToken));
        }

        [HttpPost]
        [Route("add/groups")]
        public async Task<IActionResult> AddStudents(
            [FromBody] IEnumerable<GroupRM> groups,
            [FromServices] IRepository<Faculty> facultyRepository,
            CancellationToken cancellationToken)
        {
            var groupDTOs = _mapper.Map<IEnumerable<GroupDTO>>(groups);
            await _groupService.AddGroupss(groupDTOs, facultyRepository, cancellationToken);
            return Ok();
        }

        [HttpPost]
        [Route("add/group")]
        public async Task<IActionResult> AddGroup(
            [FromServices] IRepository<Faculty> facultyRepository,
            [FromBody] GroupRM group,
            CancellationToken cancellationToken)
        {
            var groupDTO = _mapper.Map<GroupDTO>(group);
            await _groupService.AddGroup(groupDTO, facultyRepository, cancellationToken);
            return Ok();
        }

        [HttpPut]
        [Route("update/group")]
        public async Task<IActionResult> UpdateGroup(
            [FromBody] GroupRM group,
            [FromServices] IRepository<Faculty> facultyRepository,
            CancellationToken cancellationToken)
        {
            var groupDTO = _mapper.Map<GroupDTO>(group);
            await _groupService.UpdateGroup(groupDTO, facultyRepository, cancellationToken);
            return Ok();
        }

        [HttpDelete]
        [Route("delete/group/{id}")]
        public async Task<IActionResult> DeleteGroup(
            [FromRoute] int id,
            CancellationToken cancellationToken)
        {
            await _groupService.DeleteGroup(id, cancellationToken);
            return Ok();
        }
    }
}
