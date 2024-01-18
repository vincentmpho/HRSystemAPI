using System.ComponentModel.DataAnnotations;

namespace HRSystemAPI.Model
{
    public class PersonDetails
    {
        [Key]
        public int Id { get; set; }
        public string PersonCity { get; set; }
        public DateTime BirthDay { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
