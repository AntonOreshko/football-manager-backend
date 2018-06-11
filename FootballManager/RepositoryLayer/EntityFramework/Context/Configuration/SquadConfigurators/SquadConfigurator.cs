using System;
using DomainModels.Models.SquadEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RepositoryLayer.EntityFramework.Context.Configuration.SquadConfigurators
{
    public class SquadConfigurator : IEntityTypeConfiguration<Squad>
    {
        public void Configure(EntityTypeBuilder<Squad> builder)
        {
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");

            builder.Property(e => e.IsActive)
                .HasColumnName("NAME")
                .IsRequired();

            builder.Property(e => e.Formation)
                .HasColumnName("FORMATION")
                .IsRequired();

            builder.Property(e => e.ClubId)
                .IsRequired()
                .HasColumnName("CLUB_ID");

            builder.HasMany(e => e.FormationPositions)
                .WithOne(e => e.Squad)
                .HasForeignKey(e => e.SquadId);

            builder.HasKey(e => e.Id);

            builder.ToTable("SQUADS");
        }
    }
}
