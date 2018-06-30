using System.Collections.Generic;
using DomainModels.Models.ClubEntities;

namespace RepositoryLayer.Repository
{
    public interface IClubRepository : IRepository<Club>
    {
        IEnumerable<Club> GetByLevel(int level);
    }
}
