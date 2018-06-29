using DomainModels.Models.ClubEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RepositoryLayer.EntityFramework.Context.Configuration.ClubConfigurators
{
    public class SeasonResultConfigurator : IEntityTypeConfiguration<SeasonResult>
    {
        public void Configure(EntityTypeBuilder<SeasonResult> builder)
        {
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");

            builder.Property(e => e.LeaguePlace)
                .HasColumnName("LEAGUE_PLACE")
                .IsRequired();

            builder.Property(e => e.SuperleagueStage)
                .HasColumnName("SUPERLEAGUE_STAGE")
                .IsRequired();

            builder.Property(e => e.ClubHistoryId)
                .HasColumnName("CLUB_HISTORY_ID")
                .IsRequired();

            builder.HasKey(e => e.Id);

            builder.ToTable("SEASON_RESULTS");
        }
    }
}
