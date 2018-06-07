﻿using System.Collections.Generic;
using Backend.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Backend.Helpers;

namespace Backend.Models.SquadModels
{
    [Table("SQUADS")]
    public class Squad
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column("ID")]
        public int Id { get; set; }

        [Required, Column("IS_ACTIVE")]
        public bool IsActive { get; set; }

        [Required, Column("FORMATION"), MaxLength(64)]
        public string FormationString
        {
            get => Formation.ToString();
            private set => Formation = value.ParseEnum<Formation>();
        }

        [NotMapped]
        public Formation Formation { get; set; }

        [Required, Column("CLUB_ID")]
        public int ClubId { get; set; }

        [ForeignKey(nameof(ClubId))]
        public Club Club { get; set; }

        public List<FormationPosition> FormationPositions { get; set; }

    }
}
