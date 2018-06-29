using BusinessLayer.ServiceInterfaces;
using DomainModels.Models.TournamentEntities;
using RepositoryLayer.Repository;

namespace BusinessLayer.Services
{
    public class TournamentService : EntityService<Tournament>, ITournamentService
    {
        public TournamentService(IRepository<Tournament> repository) : base(repository)
        {

        }
    }
}
