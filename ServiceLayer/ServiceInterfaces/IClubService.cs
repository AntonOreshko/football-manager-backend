using System.Collections.Generic;
using DomainModels.Models.ClubEntities;

namespace BusinessLayer.ServiceInterfaces
{
    public interface IClubService : IEntityService<Club>
    {
        IEnumerable<Club> GetByLevel(int level);

        float GetAverageSquadRating(long id);

        int GetClubsCountByLevel(int level);
    }
}
