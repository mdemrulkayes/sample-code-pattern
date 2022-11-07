using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration
{
    public class EmployeeEfConfiguration: IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.EmployeeId).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();

            builder.HasMany(x => x.EmployeeEducations).WithOne(x => x.Employee);
        }
    }
}
