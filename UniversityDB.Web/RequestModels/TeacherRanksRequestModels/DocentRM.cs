using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityDB.Web.RequestModels.TeacherRanksRequestModels
{
    public class DocentRM : SeniorTeacherRM
    {
        public string DoctoryTheme { get; set; }
    }
}
