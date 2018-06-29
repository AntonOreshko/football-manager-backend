using System;
using DomainModels.Models.TournamentEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RepositoryLayer.EntityFramework.Context.Configuration.TournamentConfigurators
{
    public class TournamentConfigurator : IEntityTypeConfiguration<Tournament>
    {
        public void Configure(EntityTypeBuilder<Tournament> builder)
        {
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");

            builder.Property(e => e.Level)
                .IsRequired()
                .HasColumnName("LEVEL");

            builder.Property(e => e.CurrentStage)
                .IsRequired()
                .HasColumnName("CURRENT_STAGE");

            builder.Property(e => e.IsFinished)
                .IsRequired()
                .HasColumnName("IS_FINISHED");

            builder.Property(e => e.TournamentType)
                .IsRequired()
                .HasColumnName("TOURNAMENT_TYPE");

            builder.HasMany(e => e.TournamentClubs)
                .WithOne(e => e.Tournament)
                .HasForeignKey(e => e.TournamentId);

            builder.HasMany(e => e.Matches)
                .WithOne(e => e.Tournament)
                .HasForeignKey(e => e.TournamentId);

            builder.HasMany(e => e.TournamentPlayers)
                .WithOne(e => e.Tournament)
                .HasForeignKey(e => e.TournamentId);

            builder.HasKey(e => e.Id);

            builder.ToTable("TOURNAMENTS");
        }
    }
}
