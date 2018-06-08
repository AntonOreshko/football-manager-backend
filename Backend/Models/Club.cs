using Backend.Models.BuildingModels;
using Backend.Models.PlayerModels;
using Backend.Models.SquadModels;
using Backend.Models.StaffModels;
using Backend.Models.UserModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading;
using Backend.Enums;
using Backend.Helpers;

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

        [Required, Column("COUNTRY"), MaxLength(16)]
        public string CountryString
        {
            get => Country.ToString();
            private set => Country = value.ParseEnum<Country>();
        }

        [NotMapped]
        public Country Country { get; set; }

        [Required, Column("FOUNDATION_DATE")]
        public DateTime FoundationDate { get; set; }

        [Column("USER_ID")]
        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        #region Buildings

        [NotMapped]
        public Academy Academy
        {
            get
            {
                return (Academy)Buildings.First(b => b is Academy);
            }
        }

        [NotMapped]
        public FanClub FanClub
        {
            get
            {
                return (FanClub)Buildings.First(b => b is FanClub);
            }
        }

        [NotMapped]
        public MedicalCenter MedicalCenter
        {
            get
            {
                return (MedicalCenter)Buildings.First(b => b is MedicalCenter);
            }
        }

        [NotMapped]
        public Stadium Stadium
        {
            get
            {
                return (Stadium)Buildings.First(b => b is Stadium);
            }
        }

        #endregion

        #region Staff

        [NotMapped]
        public HeadCoach HeadCoach
        {
            get
            {
                return (HeadCoach) Staff.First(s => s is HeadCoach);
            }
        }

        [NotMapped]
        public List<HeadCoachAssistent> HeadCoachAssistents
        {
            get
            {
                return (List<HeadCoachAssistent>) Staff.Where(s => s is HeadCoachAssistent);
            }
        }

        [NotMapped]
        public List<Medic> Medics
        {
            get
            {
                return (List<Medic>)Staff.Where(s => s is Medic);
            }
        }

        [NotMapped]
        public List<Psychologist> Psychologists
        {
            get
            {
                return (List<Psychologist>)Staff.Where(s => s is Psychologist);
            }
        }

        [NotMapped]
        public List<Scout> Scouts
        {
            get
            {
                return (List<Scout>)Staff.Where(s => s is Scout);
            }
        }

        #endregion

        [NotMapped]
        public TrainingCenter TrainingCenter
        {
            get
            {
                foreach (var building in Buildings)
                {
                    if (building is TrainingCenter trainingCenter) return trainingCenter;
                }
                return null;
            }
        }

        public List<Player> Players { get; set; }

        public List<Building> Buildings { get; set; }

        public List<Employee> Staff { get; set; }

        public List<Squad> Squads { get; set; }
    }
}
