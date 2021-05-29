using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using UniversityDB.DAL.Entities;

namespace UniversityDB.BLL.DTO
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Sex Sex { get; set; }
        public bool HasChildren { get; set; }
        public decimal ScholarshipAmount { get; set; }
        public DateTime EnrolmentDate { get; set; }
        public string GroupName { get; set; }
        public string Cafedra { get; set; } 
        public int Semestr { get; set; }
        //public List<Exam> LastSessionResults { get; set; }
        //public Diploma Diploma { get; set; }
    }
}
