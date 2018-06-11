using DomainModels.Models.TournamentEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RepositoryLayer.EntityFramework.Context.Configuration.TournamentConfigurators
{
    public class TournamentClubConfigurator : IEntityTypeConfiguration<TournamentClub>
    {
        public void Configure(EntityTypeBuilder<TournamentClub> builder)
        {
            builder.Ignore(e => e.Id);

            builder.Property(e => e.TournamentId)
                .HasColumnName("TOURNAMENT_ID")
                .IsRequired();

            builder.Property(e => e.ClubId)
                .HasColumnName("CLUB_ID")
                .IsRequired();

            builder.HasKey(e => new { e.TournamentId, e.ClubId });

            builder.ToTable("TOURNAMENT_CLUBS");
        }
    }
}
