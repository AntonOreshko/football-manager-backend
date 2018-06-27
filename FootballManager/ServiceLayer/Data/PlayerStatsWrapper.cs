using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLayer.Builders;
using DomainModels.Enums;
using DomainModels.Models.PlayerEntities;

namespace BusinessLayer.Data
{
    public class PlayerStatsWrapper
    {
        #region constatnts

        public const string ACCELERATION = "Acceleration";
        public const string SPRINT_SPEED = "SprintSpeed";

        public const string SHOTS = "Shots";
        public const string LONG_SHOTS = "LongShots";
        public const string PENALTIES = "Penalties";
        public const string FREE_CICKS = "FreeKicks";

        public const string CROSSING = "ShortPassing";
        public const string SHORT_PASSING = "LongPassing";
        public const string LONG_PASSING = "Crossing";

        public const string AGILITY = "Agility";
        public const string BALL_CONTROL = "BallControl";
        public const string TRICKS = "Tricks";

        public const string INTERCEPTIONS = "Interceptions";
        public const string STANDING_TACKLES = "StandingTackles";
        public const string SLIDING_TACKLES = "SlidingTackles";

        public const string JUMPING = "Jumping";
        public const string STRENGTH = "Strength";
        public const string HEADING = "Heading";
        public const string STAMINA = "Stamina";

        public const string HAND_PLAY = "HandPlay";
        public const string KICKING = "Kicking";
        public const string REFLEXES = "Reflexes";
        public const string POSITIONING = "Positioning";

        #endregion

        #region Computed properties

        public float OverallRating => GetOverallRating();

        public float Speed => GetStatsGroupRating(StatsGroup.Speed);

        public float Shooting => GetStatsGroupRating(StatsGroup.Shooting);

        public float Passing => GetStatsGroupRating(StatsGroup.Passing);

        public float Technique => GetStatsGroupRating(StatsGroup.Technique);

        public float Defending => GetStatsGroupRating(StatsGroup.Defending);

        public float Physical => GetStatsGroupRating(StatsGroup.Physical);

        public float Goalkeeping => GetStatsGroupRating(StatsGroup.Goalkeeping);

        #endregion

        private readonly Player _player;

        private readonly PlayerStats _playerStats;

        public List<PlayerStat> Stats;

        public PlayerStatsWrapper(Player player)
        {
            _player = player;
            _playerStats = player.Stats;

            Stats = new List<PlayerStat>()
            {
                new PlayerStat(ACCELERATION, StatsGroup.Speed, f => _playerStats.Acceleration = f, () => _playerStats.Acceleration),
                new PlayerStat(SPRINT_SPEED, StatsGroup.Speed, f => _playerStats.SprintSpeed = f, () => _playerStats.SprintSpeed),

                new PlayerStat(SHOTS, StatsGroup.Shooting, f => _playerStats.Shots = f, () => _playerStats.Shots),
                new PlayerStat(LONG_SHOTS, StatsGroup.Shooting, f => _playerStats.LongShots = f, () => _playerStats.LongShots),
                new PlayerStat(PENALTIES, StatsGroup.Shooting, f => _playerStats.Penalties = f, () => _playerStats.Penalties),
                new PlayerStat(FREE_CICKS, StatsGroup.Shooting, f => _playerStats.FreeKicks = f, () => _playerStats.FreeKicks),

                new PlayerStat(SHORT_PASSING, StatsGroup.Passing, f => _playerStats.ShortPassing = f, () => _playerStats.ShortPassing),
                new PlayerStat(LONG_PASSING, StatsGroup.Passing, f => _playerStats.LongPassing = f, () => _playerStats.LongPassing),
                new PlayerStat(CROSSING, StatsGroup.Passing, f => _playerStats.Crossing = f, () => _playerStats.Crossing),

                new PlayerStat(AGILITY, StatsGroup.Technique, f => _playerStats.Agility = f, () => _playerStats.Agility),
                new PlayerStat(BALL_CONTROL, StatsGroup.Technique, f => _playerStats.BallControl = f, () => _playerStats.BallControl),
                new PlayerStat(TRICKS, StatsGroup.Technique, f => _playerStats.Tricks = f, () => _playerStats.Tricks),

                new PlayerStat(INTERCEPTIONS, StatsGroup.Defending, f => _playerStats.Interceptions = f, () => _playerStats.Interceptions),
                new PlayerStat(STANDING_TACKLES, StatsGroup.Defending, f => _playerStats.StandingTackles = f, () => _playerStats.StandingTackles),
                new PlayerStat(SLIDING_TACKLES, StatsGroup.Defending, f => _playerStats.SlidingTackles = f, () => _playerStats.SlidingTackles),

                new PlayerStat(JUMPING, StatsGroup.Physical, f => _playerStats.Jumping = f, () => _playerStats.Jumping),
                new PlayerStat(STRENGTH, StatsGroup.Physical, f => _playerStats.Strength = f, () => _playerStats.Strength),
                new PlayerStat(HEADING, StatsGroup.Physical, f => _playerStats.Heading = f, () => _playerStats.Heading),
                new PlayerStat(STAMINA, StatsGroup.Physical, f => _playerStats.Stamina = f, () => _playerStats.Stamina),

                new PlayerStat(HAND_PLAY, StatsGroup.Goalkeeping, f => _playerStats.HandPlay = f, () => _playerStats.HandPlay),
                new PlayerStat(KICKING, StatsGroup.Goalkeeping, f => _playerStats.Kicking = f, () => _playerStats.Kicking),
                new PlayerStat(REFLEXES, StatsGroup.Goalkeeping, f => _playerStats.Reflexes = f, () => _playerStats.Reflexes),
                new PlayerStat(POSITIONING, StatsGroup.Goalkeeping, f => _playerStats.Positioning = f, () => _playerStats.Positioning),
            };
        }

        public void SetValue(string statName, float value)
        {
            var stat = Stats.FirstOrDefault(s => s.Name == statName);
            if (stat != null) stat.Value = value;
            else throw new Exception("Stat \"" + statName + "\" not found!");
        }

        public float GetValue(string statName)
        {
            var stat = Stats.FirstOrDefault(s => s.Name == statName);
            if (stat != null) return stat.Value;
            throw new Exception("Stat \"" + statName + "\" not found!");
        }

        private float GetOverallRating()
        {
            var positionMapper = PlayerBuilder.GetPlayerPositionMap(_player.Position);

            var overallRating = 0.0f;

            foreach (var stat in Stats)
            {
                overallRating += stat.Value * positionMapper.StatsOverallCoefficients[stat.Name];
            }

            return overallRating;
        }

        private float GetStatsGroupRating(StatsGroup group)
        {
            var statsGroupMapper = PlayerBuilder.GetStatsGroupMap(group);

            var rating = 0.0f;
            foreach (var s in statsGroupMapper.StatsGroupCoefficients)
            {
                rating += s.Value * GetValue(s.Key);
            }
            return rating;
        }
    }

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