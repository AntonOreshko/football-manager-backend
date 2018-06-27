using DomainModels.Models.PlayerEntities;
using RepositoryLayer.EntityFramework.Context;
using RepositoryLayer.Repository;

namespace RepositoryLayer.EntityFramework
{
    public class EfPlayerRepository : EfRepository<Player>, IPlayerRepository
    {
        public EfPlayerRepository(FootballManagerContext context) : base(context)
        {

        }

        public override Player GetWithRelations(long id)
        {
            var player = Get(id);
            Context.Entry(player).Reference(p => p.Stats).Load();
            Context.Entry(player).Reference(p => p.TemporaryStats).Load();
            return player;
        }
    }
}
