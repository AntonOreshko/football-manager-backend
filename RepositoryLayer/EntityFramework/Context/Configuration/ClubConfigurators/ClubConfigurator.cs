using DomainModels.Models.ClubEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RepositoryLayer.EntityFramework.Context.Configuration.ClubConfigurators
{
    public class ClubConfigurator : IEntityTypeConfiguration<Club>
    {
        public void Configure(EntityTypeBuilder<Club> builder)
        {
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");

            builder.Property(e => e.Name)
                .HasColumnName("NAME")
                .IsRequired()
                .HasMaxLength(64);

            builder.Property(e => e.Country)
                .HasColumnName("COUNTRY")
                .IsRequired();

            builder.Property(e => e.FoundationDate)
                .HasColumnName("FOUNDATION_DATE")
                .IsRequired();

            builder.Property(e => e.Level)
                .HasColumnName("LEVEL")
                .HasDefaultValue(1)
                .IsRequired();

            builder.Property(e => e.UserId)
                .HasColumnName("USER_ID")
                .IsRequired();

            builder.HasMany(e => e.Players)
                .WithOne(e => e.Club)
                .HasForeignKey(e => e.ClubId);

            builder.HasMany(e => e.Buildings)
                .WithOne(e => e.Club)
                .HasForeignKey(e => e.ClubId);

            builder.HasMany(e => e.Employees)
                .WithOne(e => e.Club)
                .HasForeignKey(e => e.ClubId);

            builder.HasMany(e => e.Squads)
                .WithOne(e => e.Club)
                .HasForeignKey(e => e.ClubId);

            builder.HasMany(e => e.TournamentClubs)
                .WithOne(e => e.Club)
                .HasForeignKey(e => e.ClubId);

            builder.HasOne(e => e.History)
                .WithOne(e => e.Club)
                .HasForeignKey<ClubHistory>(e => e.Id);

            builder.HasOne(e => e.HollOfFame)
                .WithOne(e => e.Club)
                .HasForeignKey<HollOfFame>(e => e.Id);

            builder.HasKey(e => e.Id);

            builder.ToTable("CLUBS");
        }
    }
}
