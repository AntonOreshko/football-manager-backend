using Backend.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Backend.Helpers;
using Backend.Interfaces;

namespace Backend.Models.StaffModels
{
    [Table("EMPLOYEES")]
    public class Employee : IPerson
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

        [Required, Column("LEVEL"), Range(1, 5)]
        public int Level { get; set; }

        [Required, Column("CLUB_ID")]
        public int ClubId { get; set; }

        [ForeignKey(nameof(ClubId))]
        public virtual Club Club { get; set; }
    }
}
