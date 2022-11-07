using Domain.Common;
using Domain.Enums;

namespace Domain.Models
{
    public class Employee: BaseAuditableEntity
    {
        public Employee()
        {
            this.EmployeeEducations = new HashSet<EmployeeEducation>();
        }
        public Guid EmployeeId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public DateTime? JoiningDate { get; set; }

        public virtual ICollection<EmployeeEducation> EmployeeEducations { get; set; } 
    }
}
