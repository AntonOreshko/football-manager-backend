using BusinessLayer.ServiceInterfaces;
using DomainModels.Models;
using RepositoryLayer.Repository;

namespace BusinessLayer.Services
{
    public class UserService : EntityService<User>, IUserService
    {
        public UserService(IRepository<User> repository) : base(repository)
        {
            
        }
    }
}
