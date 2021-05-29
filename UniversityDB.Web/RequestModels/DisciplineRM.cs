using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using UniversityDB.DAL.Entities;

namespace UniversityDB.Web.RequestModels
{
    public class DisciplineRM
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Empty name.")]

        public string Name { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Empty semestres list.")]
        public List<int> Semestres { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Empty cafedra list.")]
        public List<string> Cafedras { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Empty control form field.")]
        public ControlForm ControlForm { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Empty time in hours field.")]
        public List<TimeInHours> TimeInHours { get; set; }
    }
}
