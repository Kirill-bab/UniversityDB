using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityDB.DAL.Entities.TeachersRanks
{
    [Table("Docents")]
    public class Docent : SeniorTeacher
    {
        public string DoctoryTheme { get; set; }
    }
}
