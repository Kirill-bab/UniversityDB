using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityDB.DAL.Entities.TeachersRanks
{
    [Table("SeniorTeachers")]
    public class SeniorTeacher : Assistant
    {
        public string HeadedScienceTheme { get; set; }
    }
}
