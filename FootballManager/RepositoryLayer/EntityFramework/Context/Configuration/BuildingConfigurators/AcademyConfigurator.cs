using System;
using DomainModels.Models.BuildingEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RepositoryLayer.EntityFramework.Context.Configuration.BuildingConfigurators
{
    public class AcademyConfigurator: IEntityTypeConfiguration<Academy>
    {
        public void Configure(EntityTypeBuilder<Academy> builder)
        {

        }
    }
}
