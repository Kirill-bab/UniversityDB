using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UniversityDB.DAL.Entities
{
    [Table("Disciplines")]
    public class Discipline
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Column("Semestres", TypeName = "jsonb")]
        public List<int> Semestres { get; set; }
        [Column("Cafedras", TypeName = "jsonb")]
        public List<string> Cafedras { get; set; }
        public ControlForm ControlForm { get; set; }
        [Column("TimeInHours", TypeName = "jsonb")]
        public List<TimeInHours> TimeInHours { get; set; }
    }

    public enum ControlForm
    {
        Exam,
        Credit
    }

    public enum LessonType
    {
        Lection,
        Seminar,
        LabWork,
        Coursework,
        Consultation
    }

    public class TimeInHours
    {
        public LessonType LessonType { get; set; }
        public int Hours { get; set; }
    }
}
