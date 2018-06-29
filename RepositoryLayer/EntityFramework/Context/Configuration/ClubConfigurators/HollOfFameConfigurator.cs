using DomainModels.Models.ClubEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RepositoryLayer.EntityFramework.Context.Configuration.ClubConfigurators
{
    public class HollOfFameConfigurator : IEntityTypeConfiguration<HollOfFame>
    {
        public void Configure(EntityTypeBuilder<HollOfFame> builder)
        {
            builder.Property(e => e.Id)
                .HasColumnName("ID");

            builder.HasMany(e => e.Legends)
                .WithOne(e => e.HollOfFame)
                .HasForeignKey(e => e.HollOfFameId);

            builder.HasKey(e => e.Id);

            builder.ToTable("HOLLS_OF_FAME");
        }
    }
}
