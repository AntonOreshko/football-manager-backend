using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models.UserModels
{
    [Table("USERS_REGISTER_DATA")]
    public class UserRegisterData
    {
        [Key, Column("ID")]
        public int Id { get; set; }

        [Required, Column("LOGIN"), MaxLength(64)]
        public string Login { get; set; }

        [Required, Column("PASSWORD"), MaxLength(64)]
        public string Password { get; set; }

        [ForeignKey(nameof(Id))]
        public User User { get; set; }
    }
}
