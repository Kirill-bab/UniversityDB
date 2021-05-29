using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using UniversityDB.DAL.Entities.TeachersRanks;

namespace UniversityDB.DAL.Entities
{
    [Table("Schedule")]
    public class ScheduleItem
    {
        public int Id { get; set; }
        public Group Group { get; set; }
        public Discipline Discipline { get; set; }
        public Teacher Teacher { get; set; }
        public LessonType LessonType { get; set; }
    }
}
