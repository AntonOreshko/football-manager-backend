using DomainModels.Models;
using RepositoryLayer.EntityFramework.Context;
using RepositoryLayer.Repository;

namespace RepositoryLayer.EntityFramework
{
    public class EfUserRepositiory : EfRepository<User>, IUserRepository
    {
        public EfUserRepositiory(FootballManagerContext context) : base(context)
        {

        }

        public override User GetWithRelations(long id)
        {
            var user = Get(id);
            Context.Entry(user).Reference(u => u.Club).Load();
            return user;
        }
    }
}
