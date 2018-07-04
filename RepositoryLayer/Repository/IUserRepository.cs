using DomainModels.Models.UserEntities;

namespace RepositoryLayer.Repository
{
    public interface IUserRepository: IRepository<User>, IRepositoryAsync<User>
    {

    }
}
