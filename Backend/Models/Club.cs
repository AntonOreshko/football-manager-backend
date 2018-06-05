using Backend.Models.BuildingModels;
using Backend.Models.PlayerModels;
using Backend.Models.SquadModels;
using Backend.Models.StaffModels;
using Backend.Models.UserModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Backend.Enums;

namespace Backend.Models
{
    [Table("CLUBS")]
    public class Club
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column("ID")]
        public int Id { get; set; }

        [Required, Column("NAME"), MaxLength(64)]
        public string Name { get; set; }

        [Required, Column("COUNTRY")]
        public Country Country { get; set; }

        [Required, Column("FOUNDATION_DATE")]
        public DateTime FoundationDate { get; set; }

        [Column("USER_ID")]
        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        public List<Player> Players { get; set; }

        public List<Building> Buildings { get; set; }

        public List<Employee> Staff { get; set; }

        public List<Squad> Squads { get; set; }
    }
}
