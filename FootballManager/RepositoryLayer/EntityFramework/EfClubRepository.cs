using DomainModels.Models;
using RepositoryLayer.EntityFramework.Context;
using RepositoryLayer.Repository;

namespace RepositoryLayer.EntityFramework
{
    public class EfClubRepository : EfRepository<Club>, IClubRepository
    {
        public EfClubRepository(FootballManagerContext context) : base(context)
        {

        }

        public override Club GetWithRelations(long id)
        {
            var club = Get(id);
            Context.Entry(club).Collection(c => c.Players).Load();
            return club;
        }
    }
}
