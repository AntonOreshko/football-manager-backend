using Backend.Enums;
using Backend.Models.PlayerModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models.SquadModels
{
    [Table("FORMATION_POSITIONS")]
    public class FormationPosition
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column("ID")]
        public int Id { get; set; }

        [Required, Column("PLAYER_POSITION")]
        public PlayerPosition PlayerPosition { get; set; }

        [Required, Column("FORMATION_POSITION_TYPE")]
        public FormationPositionType FormationPositionType { get; set; }

        [Column("PLAYER_ID")]
        public int PlayerId { get; set; }

        [Required, Column("FORMATION_DATA_ID")]
        public int FormationDataId { get; set; }

        [ForeignKey(nameof(FormationDataId))]
        public FormationData FormationData { get; set; }
    }
}
