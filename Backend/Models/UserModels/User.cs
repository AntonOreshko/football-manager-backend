using Backend.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Required, Column("COUNTRY")]
        public Country Country { get; set; }

        [Required, Column("COINS")]
        public int Coins { get; set; }

        [Required, Column("BOOSTERS")]
        public int Boosters { get; set; }

        public UserRegisterData UserRegisterData { get; set; }

        public Club Club { get; set; }
    }
}
