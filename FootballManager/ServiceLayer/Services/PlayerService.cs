using BusinessLayer.ServiceInterfaces;
using DomainModels.Models.PlayerEntities;
using RepositoryLayer.Repository;

namespace BusinessLayer.Services
{
    public class PlayerService : EntityService<Player>, IPlayerService
    {
        public PlayerService(IRepository<Player> repository) : base(repository)
        {

        }
    }
}
