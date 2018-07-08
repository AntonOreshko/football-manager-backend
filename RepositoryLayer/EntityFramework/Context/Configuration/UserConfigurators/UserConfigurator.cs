using DomainModels.Models.ClubEntities;
using DomainModels.Models.UserEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace RepositoryLayer.EntityFramework.Context.Configuration.UserConfigurators
{
    public class UserConfigurator : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
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

            builder.Property(e => e.Coins)
                .HasColumnName("COINS")
                .IsRequired();

            builder.Property(e => e.Boosters)
                .HasColumnName("BOOSTERS")
                .IsRequired();

            builder.Property(e => e.Login)
                .HasColumnName("LOGIN")
                .IsRequired()
                .HasMaxLength(64);

            builder.Property(e => e.Password)
                .HasColumnName("PASSWORD")
                .IsRequired()
                .HasMaxLength(64);

            builder.Property(e => e.Role)
                .HasColumnName("ROLE")
                .IsRequired();

            builder.HasOne(e => e.Club)
                .WithOne(e => e.User)
                .HasForeignKey<Club>(e => e.UserId);

            builder.HasKey(e => e.Id);

            builder.ToTable("USERS");
        }
    }
}
