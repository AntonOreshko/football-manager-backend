using DomainModels.Models.PlayerEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RepositoryLayer.EntityFramework.Context.Configuration.PlayerConfigurators
{
    public class PlayerScoresConfigurator : IEntityTypeConfiguration<PlayerScores>
    {
        public void Configure(EntityTypeBuilder<PlayerScores> builder)
        {
            builder.Property(e => e.Id)
                .HasColumnName("ID");

            builder.Property(e => e.TotalLeagueScores)
                .HasColumnName("TOTAL_LEAGUE_SCORES")
                .IsRequired();

            builder.Property(e => e.TotalLeagueAssists)
                .HasColumnName("TOTAL_LEAGUE_ASSISTS")
                .IsRequired();

            builder.Property(e => e.TotalLeagueMatches)
                .HasColumnName("TOTAL_LEAGUE_MATCHES")
                .IsRequired();

            builder.Property(e => e.TotalLeagueRating)
                .HasColumnName("TOTAL_LEAGUE_RATING")
                .IsRequired();

            builder.Property(e => e.CurrentLeagueScores)
                .HasColumnName("CURRENT_LEAGUE_SCORES")
                .IsRequired();

            builder.Property(e => e.CurrentLeagueAssists)
                .HasColumnName("CURRENT_LEAGUE_ASSISTS")
                .IsRequired();

            builder.Property(e => e.CurrentLeagueMatches)
                .HasColumnName("CURRENT_LEAGUE_MATCHES")
                .IsRequired();

            builder.Property(e => e.CurrentLeagueRating)
                .HasColumnName("CURRENT_LEAGUE_RATING")
                .IsRequired();

            builder.Property(e => e.TotalSuperleagueScores)
                .HasColumnName("TOTAL_SUPERLEAGUE_SCORES")
                .IsRequired();

            builder.Property(e => e.TotalSuperleagueAssists)
                .HasColumnName("TOTAL_SUPERLEAGUE_ASSISTS")
                .IsRequired();

            builder.Property(e => e.TotalSuperleagueMatches)
                .HasColumnName("TOTAL_SUPERLEAGUE_MATCHES")
                .IsRequired();

            builder.Property(e => e.TotalSuperleagueRating)
                .HasColumnName("TOTAL_SUPERLEAGUE_RATING")
                .IsRequired();

            builder.Property(e => e.CurrentSuperleagueScores)
                .HasColumnName("CURRENT_SUPERLEAGUE_SCORES")
                .IsRequired();

            builder.Property(e => e.CurrentSuperleagueAssists)
                .HasColumnName("CURRENT_SUPERLEAGUE_ASSISTS")
                .IsRequired();

            builder.Property(e => e.CurrentSuperleagueMatches)
                .HasColumnName("CURRENT_SUPERLEAGUE_MATCHES")
                .IsRequired();

            builder.Property(e => e.CurrentSuperleagueRating)
                .HasColumnName("CURRENT_SUPERLEAGUE_RATING")
                .IsRequired();

            builder.HasKey(e => e.Id);

            builder.ToTable("PLAYER_SCORES");
        }
    }
}
