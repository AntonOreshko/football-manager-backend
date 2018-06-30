using System.Linq;
using DomainModels.Models.TournamentEntities;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.EntityFramework.Context;
using RepositoryLayer.Repository;

namespace RepositoryLayer.EntityFramework
{
    public class EfTournamentRepository : EfRepository<Tournament>, ITournamentRepository
    {
        public EfTournamentRepository(FootballManagerContext context) : base(context)
        {

        }

        public override Tournament GetWithRelations(long id)
        {
            var tournament = Context.Tournaments
                .Include(t => t.TournamentClubs)
                .ThenInclude(tc => tc.Club)
                .Single(t => t.Id == id);

            return tournament;
        }
    }
}
