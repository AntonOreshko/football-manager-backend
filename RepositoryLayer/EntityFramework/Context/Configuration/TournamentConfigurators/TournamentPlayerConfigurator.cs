using DomainModels.Models.TournamentEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RepositoryLayer.EntityFramework.Context.Configuration.TournamentConfigurators
{
    public class TournamentPlayerConfigurator : IEntityTypeConfiguration<TournamentPlayer>
    {
        public void Configure(EntityTypeBuilder<TournamentPlayer> builder)
        {
            builder.Ignore(e => e.Id);

            builder.Property(e => e.TournamentId)
                .HasColumnName("TOURNAMENT_ID")
                .IsRequired();

            builder.Property(e => e.PlayerId)
                .HasColumnName("PLAYER_ID")
                .IsRequired();

            builder.HasKey(e => new { e.TournamentId, e.PlayerId });

            builder.ToTable("TOURNAMENT_PLAYERS");
        }
    }
}
