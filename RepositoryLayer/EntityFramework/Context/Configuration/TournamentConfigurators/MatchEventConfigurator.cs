using DomainModels.Models.TournamentEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RepositoryLayer.EntityFramework.Context.Configuration.TournamentConfigurators
{
    public class MatchEventConfigurator : IEntityTypeConfiguration<MatchEvent>
    {
        public void Configure(EntityTypeBuilder<MatchEvent> builder)
        {
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");

            builder.Property(e => e.MatchId)
                .HasColumnName("MATCH_ID")
                .IsRequired();

            builder.Property(e => e.MatchEventType)
                .HasColumnName("FORMATION")
                .IsRequired();

            builder.Property(e => e.PlayerId)
                .HasColumnName("PLAYER_ID");

            builder.HasKey(e => e.Id);

            builder.ToTable("MATCH_EVENTS");
        }
    }
}
