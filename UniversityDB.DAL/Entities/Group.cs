using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UniversityDB.DAL.Entities
{
    [Table("Groups")]
    public class Group
    {
        public int Id { get; set; }
        public string GroupCode { get; set; }
    }
}
