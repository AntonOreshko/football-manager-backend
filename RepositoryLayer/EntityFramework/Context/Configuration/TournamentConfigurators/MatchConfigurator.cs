using DomainModels.Models.TournamentEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RepositoryLayer.EntityFramework.Context.Configuration.TournamentConfigurators
{
    public class MatchConfigurator : IEntityTypeConfiguration<Match>
    {
        public void Configure(EntityTypeBuilder<Match> builder)
        {
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");

            builder.Property(e => e.Stage)
                .HasColumnName("STAGE");

            builder.Property(e => e.SubStage)
                .HasColumnName("SUB_STAGE");

            builder.Property(e => e.Group)
                .HasColumnName("GROUP");

            builder.Property(e => e.Number)
                .HasColumnName("NUMBER");

            builder.Property(e => e.HomeId)
                .HasColumnName("HOME_ID");

            builder.Property(e => e.VisitorsId)
                .HasColumnName("VISITORS_ID");

            builder.Property(e => e.StartTime)
                .HasColumnName("START_TIME");

            builder.Property(e => e.TournamentType)
                .IsRequired()
                .HasColumnName("TOURNAMENT_TYPE");

            builder.Property(e => e.TournamentId)
                .IsRequired()
                .HasColumnName("TOURNAMENT_ID");

            builder.HasMany(e => e.MatchEvents)
                .WithOne(e => e.Match)
                .HasForeignKey(e => e.MatchId);

            builder.HasKey(e => e.Id);

            builder.ToTable("MATCHES");
        }
    }
}
