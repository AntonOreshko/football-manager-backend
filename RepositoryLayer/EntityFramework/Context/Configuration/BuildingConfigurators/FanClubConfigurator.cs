using DomainModels.Models.BuildingEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RepositoryLayer.EntityFramework.Context.Configuration.BuildingConfigurators
{
    public class FanClubConfigurator : IEntityTypeConfiguration<FanClub>
    {
        public void Configure(EntityTypeBuilder<FanClub> builder)
        {
            builder.Property(e => e.Name)
                .HasColumnName("NAME")
                .IsRequired()
                .HasMaxLength(64);

            builder.Property(e => e.FansCount)
                .HasColumnName("FANS_COUNT")
                .IsRequired();
        }
    }
}
