using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UniversityDB.DAL.Entities
{
    [Table("Disciplines")]
    public class Discipline
    {
        public string Name { get; set; }
        [Column("Semestres", TypeName = "jsonb")]
        public List<int> Semestres { get; set; }
        [Column("Cafedras", TypeName = "jsonb")]
        public List<int> Cafedras { get; set; }
        public ControlForm ControlForm { get; set; }
        public Dictionary<LessonType,int> TimeInHours { get; set; }
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
}
