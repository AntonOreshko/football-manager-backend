using Backend.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Backend.Helpers;
using Backend.ViewModels;

namespace Backend.Models.UserModels
{
    [Table("USERS")]
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column("ID")]
        public int Id { get; set; }

        [Required, Column("FIRST_NAME"), MaxLength(64)]
        public string FirstName { get; set; }

        [Required, Column("LAST_NAME"), MaxLength(64)]
        public string LastName { get; set; }

        [Required, Column("COUNTRY"), MaxLength(16)]
        public string CountryString
        {
            get => Country.ToString();
            private set => Country = value.ParseEnum<Country>();
        }

        [NotMapped]
        public Country Country { get; set; }

        [Required, Column("COINS")]
        public int Coins { get; set; }

        [Required, Column("BOOSTERS")]
        public int Boosters { get; set; }

        [Required, Column("LOGIN"), MaxLength(64)]
        public string Login { get; set; }

        [Required, Column("PASSWORD"), MaxLength(64)]
        public string Password { get; set; }

        public Club Club { get; set; }

        public UserViewModel GetViewModel()
        {
            var viewModel = new UserViewModel
            {
                FirstName = FirstName,
                LastName = LastName,
                Country = Country,
                Boosters = Boosters,
                Coins = Coins
            };

            return viewModel;
        }
    }
}
