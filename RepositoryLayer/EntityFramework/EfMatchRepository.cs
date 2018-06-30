using DomainModels.Models.TournamentEntities;
using RepositoryLayer.EntityFramework.Context;
using RepositoryLayer.Repository;

namespace RepositoryLayer.EntityFramework
{
    public class EfMatchRepository : EfRepository<Match>, IMatchRepository
    {
        public EfMatchRepository(FootballManagerContext context) : base(context)
        {

        }
    }
}
