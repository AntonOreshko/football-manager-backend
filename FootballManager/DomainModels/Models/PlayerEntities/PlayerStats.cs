using DomainModels.Interfaces;

namespace DomainModels.Models.PlayerEntities
{
    public class PlayerStats : IDatabaseEntity
    {
        public long Id { get; set; }

        #region Rating Stats

        #region Speed

        public float Acceleration { get; set; }

        public float SprintSpeed { get; set; }

        #endregion

        #region Shooting

        public float Shots { get; set; }

        public float LongShots { get; set; }

        public float Penalties { get; set; }

        public float FreeKicks { get; set; }

        #endregion

        #region Passing

        public float ShortPassing { get; set; }

        public float LongPassing { get; set; }

        public float Crossing { get; set; }

        #endregion

        #region Technique

        public float Agility { get; set; }

        public float BallControl { get; set; }

        public float Tricks { get; set; }

        #endregion

        #region Defence

        public float Interceptions { get; set; }

        public float StandingTackles { get; set; }

        public float SlidingTackles { get; set; }

        #endregion

        #region Physical

        public float Jumping { get; set; }

        public float Strength { get; set; }

        public float Heading { get; set; }

        public float Stamina { get; set; }

        #endregion

        #region Goalkeepers

        public float HandPlay { get; set; }

        public float Kicking { get; set; }

        public float Reflexes { get; set; }

        public float Positioning { get; set; }

        #endregion

        #endregion

        public Player Player { get; set; }
    }
}
