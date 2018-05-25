using Microsoft.EntityFrameworkCore;

namespace FootballManager.Backend.Models
{
    public class FootballManagerDbContext: DbContext
    {
        public DbSet<User> User { get; set; }

        public DbSet<UserRegistrationData> UserRegisterData { get; set; }

        public DbSet<Club> Clubs { get; set; }
    }
}
