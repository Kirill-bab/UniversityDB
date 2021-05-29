using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using UniversityDB.DAL.Entities;
using UniversityDB.DAL.Entities.TeachersRanks;

namespace UniversityDB.Web.RequestModels
{
    public class ScheduleItemRM
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public string DisciplineName { get; set; }
        public int TeacherId { get; set; }
        public LessonType LessonType { get; set; }
    }
}
