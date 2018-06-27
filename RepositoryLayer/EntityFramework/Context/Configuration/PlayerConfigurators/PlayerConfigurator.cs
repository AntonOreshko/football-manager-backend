using DomainModels.Models.PlayerEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RepositoryLayer.EntityFramework.Context.Configuration.PlayerConfigurators
{
    public class PlayerConfigurator: IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");

            builder.Property(e => e.FirstName)
                .HasColumnName("FIRST_NAME")
                .IsRequired()
                .HasMaxLength(64);

            builder.Property(e => e.LastName)
                .HasColumnName("LAST_NAME")
                .IsRequired()
                .HasMaxLength(64);

            builder.Property(e => e.Country)
                .HasColumnName("COUNTRY")
                .IsRequired();

            builder.Property(e => e.Age)
                .HasColumnName("AGE")
                .IsRequired();

            builder.Property(e => e.Talent)
                .HasColumnName("TALENT")
                .IsRequired();

            builder.Property(e => e.Position)
                .HasColumnName("POSITION")
                .IsRequired();

            builder.Property(e => e.HeightType)
                .HasColumnName("HEIGHT_TYPE")
                .IsRequired();

            builder.Property(e => e.BodyType)
                .HasColumnName("BODY_TYPE")
                .IsRequired();

            builder.Property(e => e.Height)
                .HasColumnName("HEIGHT")
                .IsRequired();

            builder.Property(e => e.Weight)
                .HasColumnName("WEIGHT")
                .IsRequired();

            builder.Property(e => e.ClubId)
                .IsRequired()
                .HasColumnName("CLUB_ID");

            builder.HasOne(e => e.Stats)
                .WithOne(e => e.Player)
                .HasForeignKey<PlayerStats>(e => e.Id);

            builder.HasOne(e => e.TemporaryStats)
                .WithOne(e => e.Player)
                .HasForeignKey<PlayerTemporaryStats>(e => e.Id);

            builder.HasKey(e => e.Id);

            builder.ToTable("PLAYERS");
        }
    }
}
