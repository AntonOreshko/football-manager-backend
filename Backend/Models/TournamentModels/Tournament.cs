using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Backend.Enums;
using Backend.Helpers;

namespace Backend.Models.TournamentModels
{
    [Table("TOURNAMENTS")]
    public class Tournament
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column("ID")]
        public int Id { get; set; }

        [Required, Column("LEVEL")]
        public int Level { get; set; }

        [Required, Column("CURRENT_STAGE")]
        public int CurrentStage { get; set; }

        [Required, Column("TOURNAMENT_TYPE"), MaxLength(256)]
        public string TournamentTypeString
        {
            get => TournamentType.ToString();
            private set => TournamentType = value.ParseEnum<TournamentType>();
        }

        [NotMapped]
        public TournamentType TournamentType { get; set; }

        public virtual List<TournamentClub> TournamentClubs { get; set; }

        [NotMapped]
        public List<Club> Clubs
        {
            get
            {
                return TournamentClubs.Select(tc => tc.Club).ToList();
            }
        }

        public List<Match> Matches { get; set; }

        public void AddClub(Club club)
        {
            if (TournamentClubs == null) TournamentClubs = new List<TournamentClub>();
            
            TournamentClubs.Add(new TournamentClub()
            {
                Club = club, Tournament = this
            });
        }
    }
}
