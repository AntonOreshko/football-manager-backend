using DomainModels.Models;
using RepositoryLayer.Repository;

namespace BusinessLayer.ServiceInterfaces
{
    public interface IUserService
    {
        IRepository<User> UserRepository { get; set; }

        User GetUser(long id);

        void InsertUser(User user);

        void UpdateUser(User user);
    }
}
