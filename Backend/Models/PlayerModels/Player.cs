using Backend.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Backend.Builders;
using Backend.Helpers;

namespace Backend.Models.PlayerModels
{
    [Table("PLAYERS")]
    public class Player
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column("ID")]
        public int Id { get; set; }

        [Required, Column("FIRST_NAME"), MaxLength(64)]
        public string FirstName { get; set; }

        [Required, Column("LAST_NAME"), MaxLength(64)]
        public string LastName { get; set; }

        [Required, Column("AGE")]
        public int Age { get; set; }

        [Required, Column("TALENT")]
        public int Talent { get; set; }

        [Required, Column("COUNTRY"), MaxLength(16)]
        public string CountryString
        {
            get => Country.ToString();
            private set => Country = value.ParseEnum<Country>();
        }

        [NotMapped]
        public Country Country { get; set; }

        [Required, Column("FIRST_POSITION"), MaxLength(16)]
        public string FirstPositionString
        {
            get => FirstPosition.ToString();
            private set => FirstPosition = value.ParseEnum<PlayerPosition>();
        }

        [NotMapped]
        public PlayerPosition FirstPosition { get; set; }

        [Column("SECOND_POSITION"), MaxLength(16)]
        public string SecondPositionString
        {
            get => SecondPosition.ToString();
            private set => SecondPosition = value.ParseEnum<PlayerPosition>();
        }

        [NotMapped]
        public PlayerPosition SecondPosition { get; set; }

        [Column("THIRD_POSITION"), MaxLength(16)]
        public string ThirdPositionString
        {
            get => ThirdPosition.ToString();
            private set => ThirdPosition = value.ParseEnum<PlayerPosition>();
        }

        [NotMapped]
        public PlayerPosition ThirdPosition { get; set; }

        [Required, Column("HEIGHT_TYPE"), MaxLength(16)]
        public string HeightTypeString
        {
            get => HeightType.ToString();
            private set => HeightType = value.ParseEnum<HeightType>();
        }

        [NotMapped]
        public HeightType HeightType { get; set; }

        [Required, Column("BODY_TYPE"), MaxLength(16)]
        public string BodyTypeString
        {
            get => BodyType.ToString();
            private set => BodyType = value.ParseEnum<BodyType>();
        }

        [NotMapped]
        public BodyType BodyType { get; set; }

        [Required, Column("HEIGHT")]
        public int Height { get; set; }

        [Required, Column("WEIGHT")]
        public int Weight { get; set; }

        [Column("CLUB_ID")]
        public int ClubId { get; set; }

        [ForeignKey(nameof(ClubId))]
        public Club Club { get; set; }

        public PlayerStats Stats { get; set; }

        public PlayerTemporaryStats TemporaryStats { get; set; }

        #region Computed stats

        [NotMapped]
        public float OverallRating
        {
            get
            {
                if (Stats != null) return PlayerBuilder.GetOverallRating(FirstPosition, Stats);
                return 0.0f;
            }
        }

        [NotMapped]
        public float Speed
        {
            get
            {
                if (Stats != null) return PlayerBuilder.GetStatsGroupRating(StatsGroup.Speed, Stats);
                return 0.0f;
            }
        }

        [NotMapped]
        public float Shooting
        {
            get
            {
                if (Stats != null) return PlayerBuilder.GetStatsGroupRating(StatsGroup.Shooting, Stats);
                return 0.0f;
            }
        }

        [NotMapped]
        public float Passing
        {
            get
            {
                if (Stats != null) return PlayerBuilder.GetStatsGroupRating(StatsGroup.Passing, Stats);
                return 0.0f;
            }
        }

        [NotMapped]
        public float Technique
        {
            get
            {
                if (Stats != null) return PlayerBuilder.GetStatsGroupRating(StatsGroup.Technique, Stats);
                return 0.0f;
            }
        }

        [NotMapped]
        public float Defending
        {
            get
            {
                if (Stats != null) return PlayerBuilder.GetStatsGroupRating(StatsGroup.Defending, Stats);
                return 0.0f;
            }
        }

        [NotMapped]
        public float Physical
        {
            get
            {
                if (Stats != null) return PlayerBuilder.GetStatsGroupRating(StatsGroup.Physical, Stats);
                return 0.0f;
            }
        }

        [NotMapped]
        public float Goalkeeping
        {
            get
            {
                if (Stats != null) return PlayerBuilder.GetStatsGroupRating(StatsGroup.Goalkeeping, Stats);
                return 0.0f;
            }
        }

        #endregion
    }
}
