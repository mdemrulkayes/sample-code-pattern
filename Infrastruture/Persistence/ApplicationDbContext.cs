using System.Reflection;
using Application.Common.Interfaces;
using Domain.Common;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class ApplicationDbContext: DbContext, IApplicationDbContext
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IDateTimeService _dateTimeService;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ICurrentUserService currentUserService, IDateTimeService dateTimeService): base(options)
        {
            _currentUserService = currentUserService;
            _dateTimeService = dateTimeService;
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeEducation> EmployeeEducations { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseAuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _currentUserService.UserId;
                        entry.Entity.CreatedDate = _dateTimeService.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = _currentUserService.UserId;
                        entry.Entity.LastModifiedDate = _dateTimeService.Now;
                        break;
                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }

    }
}
