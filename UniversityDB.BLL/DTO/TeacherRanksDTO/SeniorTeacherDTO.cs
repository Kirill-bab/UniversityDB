using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityDB.BLL.DTO.TeacherRanksDTO
{
    public class SeniorTeacherDTO : AssistantDTO
    {
        public string HeadedScienceTheme { get; set; }
    }
}
