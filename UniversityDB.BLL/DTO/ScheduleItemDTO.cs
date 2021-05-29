using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using UniversityDB.DAL.Entities;
using UniversityDB.DAL.Entities.TeachersRanks;

namespace UniversityDB.BLL.DTO
{
    public class ScheduleItemDTO
    {
        public int Id { get; set; }
        public GroupDTO Group { get; set; }
        public DisciplineDTO Discipline { get; set; }
        public Teacher Teacher { get; set; }
        public LessonType LessonType { get; set; }
    }
}
