using DomainModels.Models.EmployeeEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RepositoryLayer.EntityFramework.Context.Configuration.EmployeeConfigurators
{
    public class EmployeeConfigurator : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");

            builder.Property(e => e.FirstName)
                .HasColumnName("FIRST_NAME")
                .IsRequired()
                .HasMaxLength(64);

            builder.Property(e => e.LastName)
                .HasColumnName("LAST_NAME")
                .IsRequired()
                .HasMaxLength(64);

            builder.Property(e => e.Country)
                .HasColumnName("COUNTRY")
                .IsRequired();

            builder.Property(e => e.Level)
                .IsRequired()
                .HasColumnName("LEVEL");

            builder.Property(e => e.ClubId)
                .IsRequired()
                .HasColumnName("CLUB_ID");

            builder.HasKey(u => u.Id);

            builder.ToTable("EMPLOYEES");
        }
    }
}
