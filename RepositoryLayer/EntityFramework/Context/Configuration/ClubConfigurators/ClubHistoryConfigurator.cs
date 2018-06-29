using DomainModels.Models.ClubEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RepositoryLayer.EntityFramework.Context.Configuration.ClubConfigurators
{
    public class ClubHistoryConfigurator : IEntityTypeConfiguration<ClubHistory>
    {
        public void Configure(EntityTypeBuilder<ClubHistory> builder)
        {
            builder.Property(e => e.Id)
                .HasColumnName("ID");

            builder.HasMany(e => e.SeasonResults)
                .WithOne(e => e.ClubHistory)
                .HasForeignKey(e => e.ClubHistoryId);

            builder.HasKey(e => e.Id);

            builder.ToTable("CLUBS_HISTORY");
        }
    }
}
