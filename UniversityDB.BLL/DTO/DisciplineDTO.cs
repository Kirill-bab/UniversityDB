using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using UniversityDB.DAL.Entities;

namespace UniversityDB.BLL.DTO
{
    public class DisciplineDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<int> Semestres { get; set; }
        public List<string> Cafedras { get; set; }
        public ControlForm ControlForm { get; set; }
        public List<TimeInHours> TimeInHours { get; set; }
    }
}
