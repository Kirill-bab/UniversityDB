using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UniversityDB.DAL.Entities
{
    [Table("Groups")]
    public class Group
    {
        [Key]
        public int GroupId { get; set; }
        public string GroupCode { get; set; }
        public string Cafedra { get; set; }
    }
}
