using DomainModels.Models.EmployeeEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RepositoryLayer.EntityFramework.Context.Configuration.EmployeeConfigurators
{
    public class HeadCoachAssistentConfigurator : IEntityTypeConfiguration<HeadCoachAssistent>
    {
        public void Configure(EntityTypeBuilder<HeadCoachAssistent> builder)
        {

        }
    }
}
