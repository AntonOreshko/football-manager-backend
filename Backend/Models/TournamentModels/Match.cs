using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models.TournamentModels
{
    [Table("MATCHES")]
    public class Match
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column("ID")]
        public int Id { get; set; }

        [Column("HOME_ID")]
        public int HomeId { get; set; }

        [NotMapped]
        public Club Home { get; set; }

        [Column("VISITORS_ID")]
        public int VisitorsId { get; set; }

        [NotMapped]
        public Club Visitors { get; set; }

        [Column("TOURNAMENT_ID")]
        public int TournamentId { get; set; }

        [ForeignKey(nameof(TournamentId))]
        public Tournament Tournament { get; set; }

        public List<MatchEvent> MatchEvents { get; set; }
    }
}
