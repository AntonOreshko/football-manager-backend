using BusinessLayer.ServiceInterfaces;
using DomainModels.Models;
using RepositoryLayer.Repository;

namespace BusinessLayer.Services
{
    public class UserService : IUserService
    {
        public IRepository<User> UserRepository { get; set; }

        public UserService(IRepository<User> userRepository)
        {
            UserRepository = userRepository;
        }

        public User GetUser(long id)
        {
            return UserRepository.Get(id);
        }

        public void InsertUser(User user)
        {
            UserRepository.Insert(user);
        }

        public void UpdateUser(User user)
        {
            UserRepository.Update(user);
        }
    }
}
