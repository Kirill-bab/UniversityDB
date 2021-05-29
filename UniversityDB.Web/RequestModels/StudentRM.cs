using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using UniversityDB.DAL.Entities;

namespace UniversityDB.Web.RequestModels
{
    public class StudentRM
    {
        public int Id { get; set; }

        [MinLength(1)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Empty first name.")]
        public string FirstName { get; set; }

        [MinLength(1)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Empty last name.")]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Empty age.")]
        public int Age { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Empty sex.")]
        [Range(0,2)]
        public Sex Sex { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Required field is empty(HasChildren).")]
        public bool HasChildren { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Empty scholarship amount.")]
        public decimal ScholarshipAmount { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Empty enrolment date.")]
        [DataType(DataType.DateTime)]
        public DateTime EnrolmentDate { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Empty group name.")]
        [StringLength(5, MinimumLength = 5)]
        public string GroupName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Empty cafedra name.")]
        public string Cafedra { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Empty semestr field.")]
        public int Semestr { get; set; }
        //public List<Exam> LastSessionResults { get; set; }
        //public Diploma Diploma { get; set; }
    }
}
