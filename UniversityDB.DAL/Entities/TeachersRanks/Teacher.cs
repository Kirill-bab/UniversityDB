using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityDB.DAL.Entities.TeachersRanks
{
    class Teacher
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Sex Sex { get; set; }
        public bool HasChildren { get; set; }
        public decimal SalarypAmount { get; set; }
        public string CandidatoryTheme { get; set; }
        public string Cafedra { get; set; }
        public bool IsStudyingInAspiranture { get; set; }
    }
}
