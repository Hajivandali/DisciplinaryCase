using System.ComponentModel.DataAnnotations;

namespace DisciplinaryCase.Models
{
    public class Discipline
    {

        [Key]
        public long Id { get; set; }

        [Required]
        public long StudentId { get; set; }

        [Required]
        public long DisciplineCategoryId { get; set; }

        public string Description { get; set; }

        public DisciplineCategory DisciplineCategory { get; set; }
        public Student Student { get; set; }
    }


}
