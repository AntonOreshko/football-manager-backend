using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Backend.Enums;
using Backend.Helpers;
using Backend.Models.PlayerModels;

namespace Backend.Models.TournamentModels
{
    [Table("MATCH_EVENTS")]
    public class MatchEvent
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column("ID")]
        public int Id { get; set; }

        [Column("MATCH_ID")]
        public int MatchId { get; set; }

        [ForeignKey(nameof(MatchId))]
        public Club Match { get; set; }

        [Required, Column("MATCH_EVENT_TYPE"), MaxLength(256)]
        public string MatchEventTypeString
        {
            get => MatchEventType.ToString();
            private set => MatchEventType = value.ParseEnum<MatchEventType>();
        }

        [NotMapped]
        public MatchEventType MatchEventType { get; set; }

        [Column("PLAYER_ID")]
        public int PlayerId { get; set; }

        [NotMapped]
        public Player Player { get; set; }
    }
}
