using DomainModels.Models.TournamentEntities;
using RepositoryLayer.EntityFramework.Context;
using RepositoryLayer.Repository;

namespace RepositoryLayer.EntityFramework
{
    public class EfTournamentRepository : EfRepository<Tournament>, ITournamentRepository
    {
        public EfTournamentRepository(FootballManagerContext context) : base(context)
        {

        }
    }
}
