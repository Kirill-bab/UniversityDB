using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UniversityDB.DAL.Entities
{
    [Table("Schedule")]
    public class ScheduleItem
    {
        public int Id { get; set; }
        public string Group { get; set; }
        public int DisciplineId { get; set; }
        public int TeacherId { get; set; }
        public LessonType LessonType { get; set; }
    }
}
