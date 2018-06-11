using DomainModels.Models.EmployeeEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RepositoryLayer.EntityFramework.Context.Configuration.EmployeeConfigurators
{
    public class ScoutConfigurator : IEntityTypeConfiguration<Scout>
    {
        public void Configure(EntityTypeBuilder<Scout> builder)
        {

        }
    }
}
