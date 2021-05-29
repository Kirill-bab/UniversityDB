using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityDB.BLL.DTO.TeacherRanksDTO
{
    public class ProffesorDTO : DocentDTO
    {
        public string HeadedScienceStream { get; set; }
    }
}
