using Clinic.NET.Domain.AggregateRoots.Patient;
using Microsoft.EntityFrameworkCore;

namespace Clinic.NET.Infrastructure.Persistence.Contexts
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(ApplicationContext).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        }
    }
}