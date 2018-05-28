using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models.PlayerModels
{
    [Table("PLAYER_TEMPORARY_STATS")]
    public class PlayerTemporaryStats
    {
        [Key, Column("ID")]
        public int Id { get; set; }

        #region Temporary Stats

        [Column("INJURY")]
        public int Injurie { get; set; }

        [Column("INJURY_DATE_TIME")]
        public DateTime InjurieDateTime { get; set; }

        [Required, Column("STAMNIA"), Range(0, 100)]
        public int Stamnia { get; set; }

        [Required, Column("STAMNIA_DATE_TIME")]
        public DateTime StamniaDateTime { get; set; }

        [Required, Column("MORALE"), Range(0, 100)]
        public int Morale { get; set; }

        [Required, Column("MORALE_DATE_TIME")]
        public DateTime MoraleDateTime { get; set; }

        #endregion

        [ForeignKey(nameof(Id))]
        public Player Player { get; set; }

    }
}
