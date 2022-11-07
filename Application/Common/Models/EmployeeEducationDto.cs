namespace Application.Common.Models
{
    public class EmployeeEducationDto
    {
        public Guid EmployeeEducationId { get; set; }
        public string? DegreeName { get; set; }
        public int PassingYear { get; set; }
        public decimal Grade { get; set; }
    }
}
