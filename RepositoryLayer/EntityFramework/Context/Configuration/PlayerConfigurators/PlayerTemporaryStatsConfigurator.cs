using DomainModels.Models.PlayerEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RepositoryLayer.EntityFramework.Context.Configuration.PlayerConfigurators
{
    public class PlayerTemporaryStatsConfigurator : IEntityTypeConfiguration<PlayerTemporaryStats>
    {
        public void Configure(EntityTypeBuilder<PlayerTemporaryStats> builder)
        {
            builder.Property(e => e.Id)
                .HasColumnName("ID");

            builder.Property(e => e.Injury)
                .HasColumnName("INJURY");

            builder.Property(e => e.InjuryDateTime)
                .HasColumnName("INJURY_DATE_TIME");

            builder.Property(e => e.Stamina)
                .IsRequired()
                .HasColumnName("STAMINA");

            builder.Property(e => e.StaminaDateTime)
                .IsRequired()
                .HasColumnName("STAMINA_DATE_TIME");

            builder.Property(e => e.Morale)
                .IsRequired()
                .HasColumnName("MORALE");

            builder.Property(e => e.MoraleDateTime)
                .IsRequired()
                .HasColumnName("MORALE_DATE_TIME");

            builder.HasKey(e => e.Id);

            builder.ToTable("PLAYER_TEMPORARY_STATS");
        }
    }
}
