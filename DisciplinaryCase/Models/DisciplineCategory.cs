using System.ComponentModel.DataAnnotations;

namespace DisciplinaryCase.Models
{
    public class DisciplineCategory
    {

        [Key]
        public long ID { get; set; }

        [Required]
        [MaxLength(500)]
        public string Name { get; set; }
    }
}
