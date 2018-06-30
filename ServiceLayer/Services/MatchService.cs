using BusinessLayer.ServiceInterfaces;
using DomainModels.Models.TournamentEntities;
using RepositoryLayer.Repository;

namespace BusinessLayer.Services
{
    public class MatchService : EntityService<Match>, IMatchService
    {
        public MatchService(IRepository<Match> repository) : base(repository)
        {

        }
    }
}
