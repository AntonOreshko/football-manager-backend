using DomainModels.Models.PlayerEntities;

namespace RepositoryLayer.Repository
{
    public interface IPlayerRepository : IRepository<Player>, IRepositoryAsync<Player>
    {

    }
}
