using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UniversityDB.Web.RequestModels
{
    public class FacultyRM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Cafedras { get; set; }
    }
}
