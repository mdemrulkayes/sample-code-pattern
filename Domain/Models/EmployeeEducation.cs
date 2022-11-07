using Domain.Common;

namespace Domain.Models
{
    public class EmployeeEducation: BaseAuditableEntity
    {
        public Guid EmployeeEducationId { get; set; }
        public string? DegreeName { get; set; }
        public int PassingYear { get; set; }
        public decimal Grade { get; set; }

        public Employee Employee { get; set; }
    }
}
