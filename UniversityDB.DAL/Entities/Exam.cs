using System;
using System.Collections.Generic;
using System.Text;
using UniversityDB.DAL.Entities.TeachersRanks;

namespace UniversityDB.DAL.Entities
{
    public class Exam
    {
        public int Id { get; set; }
        public Discipline Discipline { get; set; }
        public Teacher Teacher { get; set; }
        public int Semestr { get; set; }
        public double Mark { get; set; }
    }
}
