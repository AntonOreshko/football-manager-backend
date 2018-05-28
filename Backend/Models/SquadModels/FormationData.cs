using Backend.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models.SquadModels
{
    [Table("FORMATION_DATA")]
    public class FormationData
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column("ID")]
        public int Id { get; set; }

        [Required, Column("FORMATION")]
        public Formation Formation { get; set; }

        [Required, Column("SQUAD_ID")]
        public int SquadId { get; set; }

        [ForeignKey(nameof(SquadId))]
        public Squad Squad { get; set; }

        public List<FormationPosition> FormationPositions { get; set; }
    }
}
