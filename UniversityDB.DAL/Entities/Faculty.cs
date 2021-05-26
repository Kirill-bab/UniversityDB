using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UniversityDB.DAL.Entities
{
    [Table("Faculties")]
    public class Faculty
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Column("Cafedras", TypeName = "jsonb")]
        public List<string> Cafedras { get; set; }
    }
}
