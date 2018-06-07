using Backend.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Backend.Helpers;

namespace Backend.Models.SquadModels
{
    [Table("FORMATION_POSITIONS")]
    public class FormationPosition
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column("ID")]
        public int Id { get; set; }

        [Required, Column("PLAYER_POSITION"), MaxLength(16)]
        public string PlayerPositionString
        {
            get => PlayerPosition.ToString();
            private set => PlayerPosition = value.ParseEnum<PlayerPosition>();
        }

        [NotMapped]
        public PlayerPosition PlayerPosition { get; set; }

        [Required, Column("FORMATION_POSITION_TYPE"), MaxLength(16)]
        public string FormationPositionTypeString
        {
            get => FormationPositionType.ToString();
            private set => FormationPositionType = value.ParseEnum<FormationPositionType>();
        }

        [NotMapped]
        public FormationPositionType FormationPositionType { get; set; }

        [Column("PLAYER_ID")]
        public int PlayerId { get; set; }

        [Required, Column("SQUAD_ID")]
        public int SquadId { get; set; }

        [ForeignKey(nameof(SquadId))]
        public Squad Squad { get; set; }
    }
}
