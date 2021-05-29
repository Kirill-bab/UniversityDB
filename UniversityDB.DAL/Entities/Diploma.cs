using System;
using System.Collections.Generic;
using System.Text;
using UniversityDB.DAL.Entities.TeachersRanks;

namespace UniversityDB.DAL.Entities
{
    public class Diploma
    {
        public int Id { get; set; }
        public string Theme { get; set; }
        public Teacher Mentor { get; set; }
    }
}
