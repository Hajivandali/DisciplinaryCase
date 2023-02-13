using System.ComponentModel.DataAnnotations;

namespace DisciplinaryCase.Models
{
    public class Classroom
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
    }
}
