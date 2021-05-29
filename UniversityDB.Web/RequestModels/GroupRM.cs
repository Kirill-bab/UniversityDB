using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UniversityDB.Web.RequestModels
{
    public class GroupRM
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Empty id.")]
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Empty group code.")]
        [StringLength(5, MinimumLength = 5)]
        public string GroupCode { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Empty cafedra.")]
        public string Cafedra { get; set; }
    }
}
