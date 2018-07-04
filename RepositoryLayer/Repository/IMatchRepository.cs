using DomainModels.Models.TournamentEntities;

namespace RepositoryLayer.Repository
{
    public interface IMatchRepository : IRepository<Match>, IRepositoryAsync<Match>
    {

    }
}
