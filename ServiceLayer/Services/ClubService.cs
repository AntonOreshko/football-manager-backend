using BusinessLayer.ServiceInterfaces;
using DomainModels.Models;
using DomainModels.Models.ClubEntities;
using RepositoryLayer.Repository;

namespace BusinessLayer.Services
{
    public class ClubService : EntityService<Club>, IClubService
    {
        public ClubService(IRepository<Club> repository) : base(repository)
        {

        }
    }
}
