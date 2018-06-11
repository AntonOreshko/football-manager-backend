using DomainModels.Models.SquadEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RepositoryLayer.EntityFramework.Context.Configuration.SquadConfigurators
{
    public class FormationPositionConfigurator : IEntityTypeConfiguration<FormationPosition>
    {
        public void Configure(EntityTypeBuilder<FormationPosition> builder)
        {
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");

            builder.Property(e => e.PlayerPosition)
                .HasColumnName("PLAYER_POSITION")
                .IsRequired();

            builder.Property(e => e.FormationPositionType)
                .HasColumnName("FORMATION_POSITION_TYPE")
                .IsRequired();

            builder.Property(e => e.PlayerId)
                .HasColumnName("PLAYER_ID");

            builder.Property(e => e.SquadId)
                .IsRequired()
                .HasColumnName("SQUAD_ID");

            builder.HasKey(e => e.Id);

            builder.ToTable("FORMATION_POSITIONS");
        }
    }
}
