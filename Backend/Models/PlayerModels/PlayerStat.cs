using System;
using Backend.Enums;

namespace Backend.Models.PlayerModels
{
    public class PlayerStat
    {
        public string Name { get; set; }

        public float Value
        {
            get => getPropertyHandler();
            set => setPropertyHandler(value);
        }

        public float OverallRatingCoef { get; set; }

        public StatsGroup StatsGroup { get; set; }

        private readonly Action<float> setPropertyHandler;

        private readonly Func<float> getPropertyHandler;

        public PlayerStat(string name, StatsGroup statsGroup, Action<float> setProperty, Func<float> getProperty)
        {
            setPropertyHandler = setProperty;
            getPropertyHandler = getProperty;

            Name = name;
            StatsGroup = statsGroup;
        }
    }
}
