using DomainModels.Models.BuildingEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RepositoryLayer.EntityFramework.Context.Configuration.BuildingConfigurators
{
    public class BuildingConfigurator : IEntityTypeConfiguration<Building>
    {
        public void Configure(EntityTypeBuilder<Building> builder)
        {
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");

            builder.Property(e => e.Level)
                .IsRequired()
                .HasColumnName("LEVEL");

            builder.Property(e => e.ClubId)
                .IsRequired()
                .HasColumnName("CLUB_ID");

            builder.HasKey(u => u.Id);

            builder.ToTable("BUILDINGS");
        }
    }
}
