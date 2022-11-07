using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration
{
    public class EmployeeEducationEfConfiguration: IEntityTypeConfiguration<EmployeeEducation>
    {
        public void Configure(EntityTypeBuilder<EmployeeEducation> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.EmployeeEducationId).ValueGeneratedOnAdd();
            builder.Property(x => x.DegreeName).HasMaxLength(100).IsRequired();
            builder.HasOne(x => x.Employee).WithMany(x => x.EmployeeEducations);
        }
    }
}
