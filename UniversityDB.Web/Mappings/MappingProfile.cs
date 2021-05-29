using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using UniversityDB.BLL.DTO;
using UniversityDB.BLL.DTO.TeacherRanksDTO;
using UniversityDB.DAL.Entities;
using UniversityDB.DAL.Entities.TeachersRanks;
using UniversityDB.Web.RequestModels;
using UniversityDB.Web.RequestModels.TeacherRanksRequestModels;

namespace UniversityDB.Web.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<StudentRM, StudentDTO>();

            CreateMap<GroupRM, GroupDTO>();
            CreateMap<GroupDTO, Group>();

            CreateMap<FacultyRM, FacultyDTO>();
            CreateMap<FacultyDTO, Faculty>();

            CreateMap<DisciplineRM, DisciplineDTO>();
            CreateMap<DisciplineDTO, Discipline>();

            CreateMap<TeacherRM, TeacherDTO>();
            CreateMap<TeacherDTO, Teacher>();

            CreateMap<AssistantRM, AssistantDTO>();
            CreateMap<AssistantDTO, Assistant>();

            CreateMap<SeniorTeacherRM, SeniorTeacherDTO>();
            CreateMap<SeniorTeacherDTO, SeniorTeacher>();

            CreateMap<DocentRM, DocentDTO>();
            CreateMap<DocentDTO, Docent>();

            CreateMap<ProffesorRM, ProffesorDTO>();
            CreateMap<ProffesorDTO, Proffesor>();
        }
    }
}
