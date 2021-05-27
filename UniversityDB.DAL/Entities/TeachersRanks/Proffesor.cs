using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityDB.DAL.Entities.TeachersRanks
{
    [Table("Proffesors")]
    public class Proffesor : Docent
    {
        public string HeadedScienceStream { get; set; }
    }
}
