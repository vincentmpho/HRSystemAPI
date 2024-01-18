using System.ComponentModel.DataAnnotations;

namespace HRSystemAPI.Model
{
    public class Department
    {
        public Department()
        {
            Positions = new HashSet<Position>(); 
        }
        [Key]
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public virtual ICollection<Position> Positions { get; set; }
        
    }
}
