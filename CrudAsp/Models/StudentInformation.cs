using System.ComponentModel.DataAnnotations;

namespace CrudAsp.Models
{
    public class StudentInformation
    {
        [Key]
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int StudentAge { get; set; }
        public string StudentPhone { get; set; }
    }
}
