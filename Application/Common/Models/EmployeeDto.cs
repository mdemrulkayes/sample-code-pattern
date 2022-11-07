using Domain.Enums;

namespace Application.Common.Models
{
    public class EmployeeDto
    {
        public Guid EmployeeId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public DateTime? JoiningDate { get; set; }
        public List<EmployeeEducationDto> EmployeeEducations { get; set; }
    }
}
