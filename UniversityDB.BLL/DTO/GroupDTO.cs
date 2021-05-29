using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UniversityDB.BLL.DTO
{
    public class GroupDTO
    {
        public int Id { get; set; }
        public string GroupCode { get; set; }
        public string Cafedra { get; set; }
    }
}
