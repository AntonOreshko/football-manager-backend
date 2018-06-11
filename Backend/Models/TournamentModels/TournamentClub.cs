using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models.TournamentModels
{
    public class TournamentClub
    {
        [Key, Column("TOURNAMENT_ID")]
        public int TournamentId { get; set; }

        [ForeignKey(nameof(TournamentId))]
        public Tournament Tournament { get; set; }

        [Key, Column("CLUB_ID")]
        public int ClubId { get; set; }

        [ForeignKey(nameof(ClubId))]
        public Club Club { get; set; }
    }
}
