using DomainModels.Models.TournamentEntities;

namespace RepositoryLayer.Repository
{
    public interface ITournamentRepository : IRepository<Tournament>, IRepositoryAsync<Tournament>
    {

    }
}
