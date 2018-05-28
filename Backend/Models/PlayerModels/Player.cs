using Backend.Enums;
using Backend.Models.SquadModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models.PlayerModels
{
    [Table("PLAYERS")]
    public class Player
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column("ID")]
        public int Id { get; set; }

        [Required, Column("FIRST_NAME"), MaxLength(64)]
        public string FirstName { get; set; }

        [Required, Column("LAST_NAME"), MaxLength(64)]
        public string LastName { get; set; }

        [Required, Column("AGE")]
        public int Age { get; set; }

        [Required, Column("COUNTRY")]
        public Country Country { get; set; }

        [Required, Column("FIRST_POSITION")]
        public PlayerPosition FirstPosition { get; set; }

        [Column("SECOND_POSITION")]
        public PlayerPosition SecondPosition { get; set; }

        [Column("THIRD_POSITION")]
        public PlayerPosition ThirdPosition { get; set; }

        [Column("CLUB_ID")]
        public int ClubId { get; set; }

        [ForeignKey(nameof(ClubId))]
        public Club Club { get; set; }

        public PlayerStats Stats { get; set; }

        public PlayerTemporaryStats TemporaryStats { get; set; }

        public static Player GetPlayer()
        {
            return null;
        }
    }
}
