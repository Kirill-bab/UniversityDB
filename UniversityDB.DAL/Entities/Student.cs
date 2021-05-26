using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UniversityDB.DAL.Entities
{
    [Table("Students")]
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Sex Sex { get; set; }
        public bool HasChildren { get; set; }
        public decimal ScholarshipAmount { get; set; }
        public DateTime EnrolmentDate { get; set; }
        public string Group { get; set; }
        public string Cafedra { get; set; } 
        public int Semestr { get; set; }
    }

    public enum Sex
    {
        Male,
        Female,
        Other
    }
}
