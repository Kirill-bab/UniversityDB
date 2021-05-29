using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityDB.Web.RequestModels.TeacherRanksRequestModels
{
    public class SeniorTeacherRM : AssistantRM
    {
        public string HeadedScienceTheme { get; set; }
    }
}
