using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using UniversityDB.DAL.Entities;

namespace UniversityDB.BLL.DTO.TeacherRanksDTO
{
    public class TeacherDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Sex Sex { get; set; }
        public bool HasChildren { get; set; }
        public decimal SalaryAmount { get; set; }
        public string CandidatoryTheme { get; set; }
        public string Cafedra { get; set; }
        public bool IsStudyingInAspiranture { get; set; }
    }
}
