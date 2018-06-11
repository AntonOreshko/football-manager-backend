using System;
using DomainModels.Interfaces;

namespace DomainModels.Models.PlayerEntities
{
    public class PlayerTemporaryStats : IDatabaseEntity
    {
        public long Id { get; set; }

        #region Temporary Stats

        public int Injury { get; set; }

        public DateTime InjuryDateTime { get; set; }

        public int Stamina { get; set; }

        public DateTime StaminaDateTime { get; set; }

        public int Morale { get; set; }

        public DateTime MoraleDateTime { get; set; }

        #endregion

        public Player Player { get; set; }
    }
}
