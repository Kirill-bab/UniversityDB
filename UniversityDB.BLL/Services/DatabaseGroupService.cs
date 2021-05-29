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
    public class DatabaseGroupService : DatabaseAdminService<Group>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Student> _studentRepository;
        public DatabaseGroupService(
            IMapper mapper,
            IRepository<Group> repository,
            IRepository<Student> studentRepository,
            ILoggerFactory loggerFactory) : base(repository, loggerFactory)
        {
            _mapper = mapper;
            _studentRepository = studentRepository;
        }

        public async Task<IEnumerable<Group>> GetGroups(CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync(cancellationToken);
        }

        public async Task<Group> GetGroup(int id, CancellationToken cancellationToken)
        {
            return await _repository.GetAsync(id, cancellationToken);
        }

        public async Task AddGroupss(IEnumerable<GroupDTO> groupDTOs,
            IRepository<Faculty> facultyRepository,
            CancellationToken cancellationToken)
        {
            foreach (GroupDTO g in groupDTOs)
            {
                await ValidateGroup(g, facultyRepository, cancellationToken);
            }

            await AddRange(_mapper.Map<IEnumerable<Group>>(groupDTOs), cancellationToken);
        }
        public async Task AddGroup(GroupDTO groupDTO,
            IRepository<Faculty> facultyRepository,
            CancellationToken cancellationToken)
        {
            await ValidateGroup(groupDTO, facultyRepository, cancellationToken);
            await Add( _mapper.Map<Group>(groupDTO), cancellationToken);
        }
        public async Task UpdateGroup(GroupDTO groupDTO,
            IRepository<Faculty> facultyRepository,
            CancellationToken cancellationToken)
        {
            await ValidateGroup(groupDTO, facultyRepository, cancellationToken);
            await Update(_mapper.Map<Group>(groupDTO), cancellationToken);
        }
        public async Task DeleteGroup(int id, CancellationToken cancellationToken)
        {
            if (!(await _repository.GetAllAsync(cancellationToken)).Select(p => p.GroupId).Contains(id)) throw new KeyNotFoundException("Id");
            foreach(Student s in (await _studentRepository.GetAllAsync(cancellationToken)).Where(p => p.GroupId == id))
            {
                s.Group = null;
            }

            await Delete(id, cancellationToken);
        }

        private async Task ValidateGroup(GroupDTO groupDTO,
            IRepository<Faculty> facultyRepository,
            CancellationToken cancellationToken)
        {
            var groups = await _repository.GetAllAsync(cancellationToken);
            if (groups.Select(p => p.GroupId).Contains(groupDTO.Id) || groups.Select(g => g.GroupCode).Contains(groupDTO.GroupCode))
                throw new DuplicateException(groupDTO.GroupCode);

            var cafedraList = (await facultyRepository.GetAllAsync(cancellationToken)).Select(f => f.Cafedras);
            foreach (List<string> cafedra in cafedraList)
            {
                if (!cafedra.Contains(groupDTO.Cafedra)) throw new CafedraNotFoundException(groupDTO.Cafedra);
            }
        }
    }
}
