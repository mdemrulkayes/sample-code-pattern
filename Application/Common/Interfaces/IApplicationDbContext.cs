using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Domain.Models.Employee> Employees { get; set; }

        DbSet<EmployeeEducation> EmployeeEducations { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
