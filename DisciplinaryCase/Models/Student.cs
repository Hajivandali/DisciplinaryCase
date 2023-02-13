using System.ComponentModel.DataAnnotations;

namespace DisciplinaryCase.Models
{
    public class Student
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string MeliCode { get; set; }
        [Required]
        public long ClassroomId { get; set; }

        public Classroom Classroom { get; set; }
    }
}
