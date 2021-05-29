using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityDB.DAL.Entities;

namespace UniversityDB.Web.RequestModels
{
    public class CommonStudentRequestModel
    {
        public List<string> Groups { get; set; }
        public List<int> Courses { get; set; }
        public string Faculty { get; set; }
        public Sex Sex { get; set; }
        public int Age { get; set; }
        public bool HasChildren { get; set; }
        public decimal ScholarshipAmount { get; set; }
    }
}
