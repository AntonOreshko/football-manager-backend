using System.Collections.Generic;
using System.Linq;
using DomainModels.Models.ClubEntities;
using Microsoft.EntityFrameworkCore;
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
            var club = Entities
                .Include(c => c.Players)
                    .ThenInclude(p => p.Stats)
                .Include(p=>p.Players)
                    .ThenInclude(p => p.TemporaryStats)
                .Single(c => c.Id == id);

            return club;
        }

        public IEnumerable<Club> GetByLevel(int level)
        {
            return Entities.Where(c => c.Level == level);
        }
    }
}
