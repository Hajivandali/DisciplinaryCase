using System.ComponentModel.DataAnnotations;

namespace DisciplinaryCase.Models
{
    public class Discipline
    {
        [Key]
        public long id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ClassId { get; set; }
        public int NationalCode { get; set; }
        public string BodyDiscipline { get; set; }
        public DateTime CreationDate { get; set; }

        public Discipline(int id, string firstName, string lastName, string classId, int nationalCode, string bodyDiscipline, DateTime creationDate)
        {
            this.id = id;
            FirstName = firstName;
            LastName = lastName;
            ClassId = classId;
            NationalCode = nationalCode;
            BodyDiscipline = bodyDiscipline;
            CreationDate = DateTime.Now;
        }
    }


}
