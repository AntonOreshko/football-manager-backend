using DomainModels.Models.PlayerEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RepositoryLayer.EntityFramework.Context.Configuration.PlayerConfigurators
{
    public class PlayerStatsConfigurator : IEntityTypeConfiguration<PlayerStats>
    {
        public void Configure(EntityTypeBuilder<PlayerStats> builder)
        {
            builder.Property(e => e.Id)
                .HasColumnName("ID");

            builder.Property(e => e.Acceleration)
                .HasColumnName("ACCELERATION")
                .IsRequired();

            builder.Property(e => e.SprintSpeed)
                .HasColumnName("SPRINT_SPEED")
                .IsRequired();

            builder.Property(e => e.Shots)
                .HasColumnName("SHOTS")
                .IsRequired();

            builder.Property(e => e.LongShots)
                .HasColumnName("LONG_SHOTS")
                .IsRequired();

            builder.Property(e => e.Penalties)
                .HasColumnName("PENALTIES")
                .IsRequired();

            builder.Property(e => e.FreeKicks)
                .HasColumnName("FREE_KICKS")
                .IsRequired();

            builder.Property(e => e.ShortPassing)
                .HasColumnName("SHORT_PASSING")
                .IsRequired();

            builder.Property(e => e.LongPassing)
                .HasColumnName("LONG_PASSING")
                .IsRequired();

            builder.Property(e => e.Crossing)
                .HasColumnName("CROSSING")
                .IsRequired();

            builder.Property(e => e.Agility)
                .HasColumnName("AGILITY")
                .IsRequired();

            builder.Property(e => e.BallControl)
                .HasColumnName("BALL_CONTROL")
                .IsRequired();

            builder.Property(e => e.Tricks)
                .HasColumnName("TRICKS")
                .IsRequired();

            builder.Property(e => e.Interceptions)
                .HasColumnName("INTERCEPTIONS")
                .IsRequired();

            builder.Property(e => e.StandingTackles)
                .HasColumnName("STANDING_TACKLES")
                .IsRequired();

            builder.Property(e => e.SlidingTackles)
                .HasColumnName("SLIDING_TACKLES")
                .IsRequired();

            builder.Property(e => e.Jumping)
                .HasColumnName("JUMPING")
                .IsRequired();

            builder.Property(e => e.Strength)
                .HasColumnName("STRENGTH")
                .IsRequired();

            builder.Property(e => e.Heading)
                .HasColumnName("HEADING")
                .IsRequired();

            builder.Property(e => e.Stamina)
                .HasColumnName("STAMINA")
                .IsRequired();

            builder.Property(e => e.HandPlay)
                .HasColumnName("HAND_PLAY")
                .IsRequired();

            builder.Property(e => e.Kicking)
                .HasColumnName("KICKING")
                .IsRequired();

            builder.Property(e => e.Reflexes)
                .HasColumnName("REFLEXES")
                .IsRequired();

            builder.Property(e => e.Positioning)
                .HasColumnName("POSITIONING")
                .IsRequired();

            builder.HasKey(e => e.Id);

            builder.ToTable("PLAYER_STATS");
        }
    }
}
