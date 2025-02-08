using Clinic.NET.Domain.AggregateRoots;
using Clinic.NET.Domain.AggregateRoots.Patient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clinic.NET.Infrastructure.Persistence.Configuration
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.ToTable("Patients");

            builder.Property(p => p.Id)
                .HasConversion(pid => pid.ToString(), pid => new PatientId(Guid.Parse(pid)))
                .IsRequired(true)
                .HasMaxLength(36);

            builder.HasKey(p => p.Id);

            builder.OwnsOne(p => p.FullName, name =>
            {
                name.Property(p => p.Value)
                    .IsRequired(true)
                    .HasColumnName("full_name")
                    .HasColumnType("nvarchar")
                    .HasMaxLength(250);
            });

            builder.Property(p => p.DateOfBirth)
                .IsRequired(true)
                .HasColumnName("date_of_birth")
                .HasColumnType("date");

            builder.OwnsOne(p => p.PhoneNumber, phoneNumber =>
            {
                phoneNumber.Property(t => t.ValuePhoneNumber)
                    .IsRequired(true)
                    .HasColumnName("phone_number")
                    .HasColumnType("int");
            });

            builder.OwnsOne(p => p.Email, email =>
            {
                email.Property(t => t.ValueEmail)
                    .IsRequired(true)
                    .HasColumnName("email")
                    .HasColumnType("nvarchar")
                    .HasMaxLength(250);
            });

            builder.OwnsOne(p => p.Identification, identification =>
            {
                identification.Property(t => t.ValueIdentification)
                    .IsRequired(true)
                    .HasColumnName("identification")
                    .HasColumnType("int");
            });

            builder.Property(p => p.InsuranceType)
                .IsRequired(false)
                .HasColumnName("insurance_type")
                .HasColumnType("nvarchar");
        }
    }
}