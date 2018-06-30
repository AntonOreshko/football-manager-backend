using System.Collections.Generic;
using System.Linq;
using BusinessLayer.Data;
using BusinessLayer.ServiceInterfaces;
using DomainModels.Models.ClubEntities;
using RepositoryLayer.Repository;

namespace BusinessLayer.Services
{
    public class ClubService : EntityService<Club>, IClubService
    {
        public ClubService(IRepository<Club> repository) : base(repository)
        {

        }

        public IEnumerable<Club> GetByLevel(int level)
        {
            return ((IClubRepository)Repository).GetByLevel(level);
        }

        public float GetAverageSquadRating(long id)
        {
            var club = GetWithRelations(id);

            var wrappers = club.Players.Select(PlayerStatsWrapper.Get).ToList();
            var aggregateRating = wrappers.Sum(w => w.OverallRating);

            return aggregateRating / wrappers.Count();
        }

        public int GetClubsCountByLevel(int level)
        {
            return GetByLevel(level).Count();
        }
    }
}
