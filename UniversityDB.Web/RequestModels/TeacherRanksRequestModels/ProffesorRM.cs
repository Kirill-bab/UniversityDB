using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityDB.Web.RequestModels.TeacherRanksRequestModels
{
    public class ProffesorRM : DocentRM
    {
        public string HeadedScienceStream { get; set; }
    }
}
