using DomainModels.Models.EmployeeEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RepositoryLayer.EntityFramework.Context.Configuration.EmployeeConfigurators
{
    public class HeadCoachConfigurator : IEntityTypeConfiguration<HeadCoach>
    {
        public void Configure(EntityTypeBuilder<HeadCoach> builder)
        {

        }
    }
}
