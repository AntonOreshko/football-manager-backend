using DomainModels.Models.PlayerEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RepositoryLayer.EntityFramework.Context.Configuration.PlayerConfigurators
{
    public class LegendConfigurator : IEntityTypeConfiguration<Legend>
    {
        public void Configure(EntityTypeBuilder<Legend> builder)
        {
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");

            builder.Property(e => e.LegendType)
                .HasColumnName("LEGEND_TYPE")
                .IsRequired();

            builder.Property(e => e.Result)
                .HasColumnName("RESULT")
                .IsRequired();

            builder.Property(e => e.Matches)
                .HasColumnName("MATCHES")
                .IsRequired();

            builder.Property(e => e.HollOfFameId)
                .HasColumnName("HOLL_OF_FAME_ID")
                .IsRequired();

            builder.Property(e => e.HollOfFameId)
                .HasColumnName("PLAYER_ID")
                .IsRequired();

            builder.HasKey(e => e.Id);

            builder.ToTable("LEGENDS");
        }
    }
}
