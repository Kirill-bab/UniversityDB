using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityDB.BLL.DTO.TeacherRanksDTO
{
    public class DocentDTO : SeniorTeacherDTO
    {
        public string DoctoryTheme { get; set; }
    }
}
