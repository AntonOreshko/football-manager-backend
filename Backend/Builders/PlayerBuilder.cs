using Backend.Enums;
using Backend.Helpers;
using Backend.Models;
using Backend.Models.PlayerModels;
using Backend.Models.SquadModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Builders
{
    public static class PlayerBuilder
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

        #endregion

        #region random generators

        #region Player stats coefficients initialization fields 

        private static Dictionary<PlayerPosition, Dictionary<string, float>> statsCoefficients;

        private static Dictionary<StatsGroup, Dictionary<string, float>> statsGroupsCoefficients;

        private static List<PlayerPositionDependentBuilder> positionDependentBuilders;

        #endregion

        #endregion

        static PlayerBuilder()
        {
            #region Player stats groups coefficients intialization

            statsCoefficients = new Dictionary<PlayerPosition, Dictionary<string, float>>
            {
                {
                    PlayerPosition.LB, new Dictionary<string, float>
                    {
                        { ACCELERATION, 0.1f }, { SPRINT_SPEED, 0.1f },
                        { SHOTS, 0.01f }, { LONG_SHOTS, 0.01f }, { PENALTIES, 0.005f }, { FREE_CICKS, 0.005f },
                        { CROSSING, 0.05f }, { SHORT_PASSING, 0.04f }, { LONG_PASSING, 0.04f },
                        { AGILITY, 0.04f }, { BALL_CONTROL, 0.04f }, { TRICKS, 0.005f },
                        { INTERCEPTIONS, 0.125f }, { STANDING_TACKLES, 0.08f }, { SLIDING_TACKLES, 0.09f },
                        { JUMPING, 0.08f }, { STRENGTH, 0.05f }, { HEADING, 0.05f }, { STAMINA, 0.08f },
                    }
                },
                {
                    PlayerPosition.RB, new Dictionary<string, float>
                    {
                        { ACCELERATION, 0.1f }, { SPRINT_SPEED, 0.1f },
                        { SHOTS, 0.01f }, { LONG_SHOTS, 0.01f }, { PENALTIES, 0.005f }, { FREE_CICKS, 0.005f },
                        { CROSSING, 0.05f }, { SHORT_PASSING, 0.04f }, { LONG_PASSING, 0.04f },
                        { AGILITY, 0.04f }, { BALL_CONTROL, 0.04f }, { TRICKS, 0.005f },
                        { INTERCEPTIONS, 0.125f }, { STANDING_TACKLES, 0.08f }, { SLIDING_TACKLES, 0.09f },
                        { JUMPING, 0.08f }, { STRENGTH, 0.05f }, { HEADING, 0.05f }, { STAMINA, 0.08f },
                    }
                },
                {
                    PlayerPosition.CB, new Dictionary<string, float>
                    {
                        { ACCELERATION, 0.08f }, { SPRINT_SPEED, 0.08f },
                        { SHOTS, 0.01f }, { LONG_SHOTS, 0.01f }, { PENALTIES, 0.005f }, { FREE_CICKS, 0.005f },
                        { CROSSING, 0.01f }, { SHORT_PASSING, 0.04f }, { LONG_PASSING, 0.04f },
                        { AGILITY, 0.03f }, { BALL_CONTROL, 0.03f }, { TRICKS, 0.05f },
                        { INTERCEPTIONS, 0.145f }, { STANDING_TACKLES, 0.1f }, { SLIDING_TACKLES, 0.1f },
                        { JUMPING, 0.09f }, { STRENGTH, 0.08f }, { HEADING, 0.07f }, { STAMINA, 0.07f },
                    }
                },
                {
                    PlayerPosition.CDM, new Dictionary<string, float>
                    {
                        { ACCELERATION, 0.06f }, { SPRINT_SPEED, 0.06f },
                        { SHOTS, 0.02f }, { LONG_SHOTS, 0.02f }, { PENALTIES, 0.005f }, { FREE_CICKS, 0.005f },
                        { CROSSING, 0.02f }, { SHORT_PASSING, 0.1f }, { LONG_PASSING, 0.08f },
                        { AGILITY, 0.03f }, { BALL_CONTROL, 0.05f }, { TRICKS, 0.005f },
                        { INTERCEPTIONS, 0.11f }, { STANDING_TACKLES, 0.085f }, { SLIDING_TACKLES, 0.09f },
                        { JUMPING, 0.08f }, { STRENGTH, 0.07f }, { HEADING, 0.05f }, { STAMINA, 0.06f },
                    }
                },
                {
                    PlayerPosition.CM, new Dictionary<string, float>
                    {
                        { ACCELERATION, 0.05f }, { SPRINT_SPEED, 0.04f },
                        { SHOTS, 0.04f }, { LONG_SHOTS, 0.04f }, { PENALTIES, 0.005f }, { FREE_CICKS, 0.005f },
                        { CROSSING, 0.02f }, { SHORT_PASSING, 0.15f }, { LONG_PASSING, 0.125f },
                        { AGILITY, 0.05f }, { BALL_CONTROL, 0.08f }, { TRICKS, 0.005f },
                        { INTERCEPTIONS, 0.07f }, { STANDING_TACKLES, 0.05f }, { SLIDING_TACKLES, 0.04f },
                        { JUMPING, 0.05f }, { STRENGTH, 0.06f }, { HEADING, 0.05f }, { STAMINA, 0.07f },
                    }
                },
                {
                    PlayerPosition.LM, new Dictionary<string, float>
                    {
                        { ACCELERATION, 0.1f }, { SPRINT_SPEED, 0.1f },
                        { SHOTS, 0.03f }, { LONG_SHOTS, 0.03f }, { PENALTIES, 0.005f }, { FREE_CICKS, 0.005f },
                        { CROSSING, 0.05f }, { SHORT_PASSING, 0.08f }, { LONG_PASSING, 0.08f },
                        { AGILITY, 0.1f }, { BALL_CONTROL, 0.1f }, { TRICKS, 0.05f },
                        { INTERCEPTIONS, 0.05f }, { STANDING_TACKLES, 0.015f }, { SLIDING_TACKLES, 0.02f },
                        { JUMPING, 0.05f }, { STRENGTH, 0.04f }, { HEADING, 0.05f }, { STAMINA, 0.09f },
                    }
                },
                {
                    PlayerPosition.RM, new Dictionary<string, float>
                    {
                        { ACCELERATION, 0.1f }, { SPRINT_SPEED, 0.1f },
                        { SHOTS, 0.03f }, { LONG_SHOTS, 0.03f }, { PENALTIES, 0.005f }, { FREE_CICKS, 0.005f },
                        { CROSSING, 0.05f }, { SHORT_PASSING, 0.08f }, { LONG_PASSING, 0.08f },
                        { AGILITY, 0.1f }, { BALL_CONTROL, 0.1f }, { TRICKS, 0.05f },
                        { INTERCEPTIONS, 0.05f }, { STANDING_TACKLES, 0.015f }, { SLIDING_TACKLES, 0.02f },
                        { JUMPING, 0.05f }, { STRENGTH, 0.04f }, { HEADING, 0.05f }, { STAMINA, 0.09f },
                    }
                },
                {
                    PlayerPosition.CAM, new Dictionary<string, float>
                    {
                        { ACCELERATION, 0.08f }, { SPRINT_SPEED, 0.08f },
                        { SHOTS, 0.1f }, { LONG_SHOTS, 0.1f }, { PENALTIES, 0.005f }, { FREE_CICKS, 0.005f },
                        { CROSSING, 0.02f }, { SHORT_PASSING, 0.12f }, { LONG_PASSING, 0.07f },
                        { AGILITY, 0.1f }, { BALL_CONTROL, 0.1f }, { TRICKS, 0.005f },
                        { INTERCEPTIONS, 0.025f }, { STANDING_TACKLES, 0.01f }, { SLIDING_TACKLES, 0.01f },
                        { JUMPING, 0.03f }, { STRENGTH, 0.03f }, { HEADING, 0.003f }, { STAMINA, 0.08f },
                    }
                },
                {
                    PlayerPosition.LF, new Dictionary<string, float>
                    {
                        { ACCELERATION, 0.1f }, { SPRINT_SPEED, 0.1f },
                        { SHOTS, 0.11f }, { LONG_SHOTS, 0.05f }, { PENALTIES, 0.005f }, { FREE_CICKS, 0.005f },
                        { CROSSING, 0.05f }, { SHORT_PASSING, 0.07f }, { LONG_PASSING, 0.03f },
                        { AGILITY, 0.12f }, { BALL_CONTROL, 0.12f }, { TRICKS, 0.05f },
                        { INTERCEPTIONS, 0.015f }, { STANDING_TACKLES, 0.01f }, { SLIDING_TACKLES, 0.01f },
                        { JUMPING, 0.03f }, { STRENGTH, 0.04f }, { HEADING, 0.03f }, { STAMINA, 0.1f },
                    }
                },
                {
                    PlayerPosition.RF, new Dictionary<string, float>
                    {
                        { ACCELERATION, 0.1f }, { SPRINT_SPEED, 0.1f },
                        { SHOTS, 0.11f }, { LONG_SHOTS, 0.05f }, { PENALTIES, 0.005f }, { FREE_CICKS, 0.005f },
                        { CROSSING, 0.05f }, { SHORT_PASSING, 0.07f }, { LONG_PASSING, 0.03f },
                        { AGILITY, 0.12f }, { BALL_CONTROL, 0.12f }, { TRICKS, 0.05f },
                        { INTERCEPTIONS, 0.015f }, { STANDING_TACKLES, 0.01f }, { SLIDING_TACKLES, 0.01f },
                        { JUMPING, 0.03f }, { STRENGTH, 0.04f }, { HEADING, 0.03f }, { STAMINA, 0.1f },
                    }
                },
                {
                    PlayerPosition.ST, new Dictionary<string, float>
                    {
                        { ACCELERATION, 0.1f }, { SPRINT_SPEED, 0.1f },
                        { SHOTS, 0.14f }, { LONG_SHOTS, 0.08f }, { PENALTIES, 0.005f }, { FREE_CICKS, 0.005f },
                        { CROSSING, 0.01f }, { SHORT_PASSING, 0.03f }, { LONG_PASSING, 0.01f },
                        { AGILITY, 0.1f }, { BALL_CONTROL, 0.12f }, { TRICKS, 0.005f },
                        { INTERCEPTIONS, 0.015f }, { STANDING_TACKLES, 0.01f }, { SLIDING_TACKLES, 0.01f },
                        { JUMPING, 0.06f }, { STRENGTH, 0.06f }, { HEADING, 0.06f }, { STAMINA, 0.08f },
                    }
                },
            };

            statsGroupsCoefficients = new Dictionary<StatsGroup, Dictionary<string, float>>
            {
                {
                    StatsGroup.Speed, new Dictionary<string, float>
                    {
                        { ACCELERATION, 0.5f }, { SPRINT_SPEED, 0.5f }
                    }                    
                },
                {
                    StatsGroup.Shooting, new Dictionary<string, float>
                    {
                        { SHOTS, 0.6f }, { LONG_SHOTS, 0.3f }, { PENALTIES, 0.05f }, { FREE_CICKS, 0.05f }
                    }
                },
                {
                    StatsGroup.Passing, new Dictionary<string, float>
                    {
                        { SHORT_PASSING, 0.50f }, { LONG_PASSING, 0.25f }, { CROSSING, 0.25f }
                    }
                },
                {
                    StatsGroup.Technique, new Dictionary<string, float>
                    {
                        { AGILITY, 0.45f }, { BALL_CONTROL, 0.45f }, { TRICKS, 0.1f }
                    }
                },
                {
                    StatsGroup.Defending, new Dictionary<string, float>
                    {
                        { INTERCEPTIONS, 0.4f }, { STANDING_TACKLES, 0.3f }, { SLIDING_TACKLES, 0.3f }
                    }
                },
                {
                    StatsGroup.Physical, new Dictionary<string, float>
                    {
                        { JUMPING, 0.2f }, { STRENGTH, 0.5f }, { HEADING, 0.2f }, { STAMINA, 0.1f }
                    }
                },
            };

            #endregion

            #region Position dependent builders

            positionDependentBuilders = new List<PlayerPositionDependentBuilder>()
            {
                new PlayerPositionDependentBuilder()
                {
                    PlayerPosition = PlayerPosition.LB,
                    HeightCreator = new RandomRangesCreator<HeightType>(
                        new List<HeightType> { HeightType.Little, HeightType.Medium, HeightType.UpperMedium, HeightType.Tall }, 
                        new List<int> { 25, 25, 25, 25 }),
                    BodyCreator = new RandomRangesCreator<BodyType>(
                        new List<BodyType> { BodyType.Lean, BodyType.Normal, BodyType.Thick },
                        new List<int> { 25, 25, 25, 25 }),
                    StatsGenerationMedianas = new Dictionary<StatsGroup, float>
                    {
                        { StatsGroup.Speed, 50 }, { StatsGroup.Shooting, 35 }, { StatsGroup.Passing, 40 },
                        { StatsGroup.Technique, 45 }, { StatsGroup.Defending, 65 }, { StatsGroup.Physical, 55 },
                    }
                },
                new PlayerPositionDependentBuilder()
                {
                    PlayerPosition = PlayerPosition.RB,
                    HeightCreator = new RandomRangesCreator<HeightType>(
                        new List<HeightType> { HeightType.Little, HeightType.Medium, HeightType.UpperMedium, HeightType.Tall },
                        new List<int> { 25, 25, 25, 25 }),
                    BodyCreator = new RandomRangesCreator<BodyType>(
                        new List<BodyType> { BodyType.Lean, BodyType.Normal, BodyType.Thick },
                        new List<int> { 25, 25, 25, 25 }),
                    StatsGenerationMedianas = new Dictionary<StatsGroup, float>
                    {
                        { StatsGroup.Speed, 50 }, { StatsGroup.Shooting, 35 }, { StatsGroup.Passing, 40 },
                        { StatsGroup.Technique, 45 }, { StatsGroup.Defending, 65 }, { StatsGroup.Physical, 55 },
                    }
                },
                new PlayerPositionDependentBuilder()
                {
                    PlayerPosition = PlayerPosition.CB,
                    HeightCreator = new RandomRangesCreator<HeightType>(
                        new List<HeightType> { HeightType.Little, HeightType.Medium, HeightType.UpperMedium, HeightType.Tall },
                        new List<int> { 25, 25, 25, 25 }),
                    BodyCreator = new RandomRangesCreator<BodyType>(
                        new List<BodyType> { BodyType.Lean, BodyType.Normal, BodyType.Thick },
                        new List<int> { 25, 25, 25, 25 }),
                    StatsGenerationMedianas = new Dictionary<StatsGroup, float>
                    {
                        { StatsGroup.Speed, 45 }, { StatsGroup.Shooting, 35 }, { StatsGroup.Passing, 35 },
                        { StatsGroup.Technique, 35 }, { StatsGroup.Defending, 65 }, { StatsGroup.Physical, 65 },
                    }
                },
                new PlayerPositionDependentBuilder()
                {
                    PlayerPosition = PlayerPosition.CDM,
                    HeightCreator = new RandomRangesCreator<HeightType>(
                        new List<HeightType> { HeightType.Little, HeightType.Medium, HeightType.UpperMedium, HeightType.Tall },
                        new List<int> { 25, 25, 25, 25 }),
                    BodyCreator = new RandomRangesCreator<BodyType>(
                        new List<BodyType> { BodyType.Lean, BodyType.Normal, BodyType.Thick },
                        new List<int> { 25, 25, 25, 25 }),
                    StatsGenerationMedianas = new Dictionary<StatsGroup, float>
                    {
                        { StatsGroup.Speed, 40 }, { StatsGroup.Shooting, 45 }, { StatsGroup.Passing, 55 },
                        { StatsGroup.Technique, 40 }, { StatsGroup.Defending, 55 }, { StatsGroup.Physical, 55 },
                    }
                },
                new PlayerPositionDependentBuilder()
                {
                    PlayerPosition = PlayerPosition.CM,
                    HeightCreator = new RandomRangesCreator<HeightType>(
                        new List<HeightType> { HeightType.Little, HeightType.Medium, HeightType.UpperMedium, HeightType.Tall },
                        new List<int> { 25, 25, 25, 25 }),
                    BodyCreator = new RandomRangesCreator<BodyType>(
                        new List<BodyType> { BodyType.Lean, BodyType.Normal, BodyType.Thick },
                        new List<int> { 25, 25, 25, 25 }),
                    StatsGenerationMedianas = new Dictionary<StatsGroup, float>
                    {
                        { StatsGroup.Speed, 40 }, { StatsGroup.Shooting, 50 }, { StatsGroup.Passing, 65 },
                        { StatsGroup.Technique, 55 }, { StatsGroup.Defending, 45 }, { StatsGroup.Physical, 45 },
                    }
                },
                new PlayerPositionDependentBuilder()
                {
                    PlayerPosition = PlayerPosition.LM,
                    HeightCreator = new RandomRangesCreator<HeightType>(
                        new List<HeightType> { HeightType.Little, HeightType.Medium, HeightType.UpperMedium, HeightType.Tall },
                        new List<int> { 25, 25, 25, 25 }),
                    BodyCreator = new RandomRangesCreator<BodyType>(
                        new List<BodyType> { BodyType.Lean, BodyType.Normal, BodyType.Thick },
                        new List<int> { 25, 25, 25, 25 }),
                    StatsGenerationMedianas = new Dictionary<StatsGroup, float>
                    {
                        { StatsGroup.Speed, 55 }, { StatsGroup.Shooting, 50 }, { StatsGroup.Passing, 55 },
                        { StatsGroup.Technique, 60 }, { StatsGroup.Defending, 40 }, { StatsGroup.Physical, 35 },
                    }
                },
                new PlayerPositionDependentBuilder()
                {
                    PlayerPosition = PlayerPosition.RM,
                    HeightCreator = new RandomRangesCreator<HeightType>(
                        new List<HeightType> { HeightType.Little, HeightType.Medium, HeightType.UpperMedium, HeightType.Tall },
                        new List<int> { 25, 25, 25, 25 }),
                    BodyCreator = new RandomRangesCreator<BodyType>(
                        new List<BodyType> { BodyType.Lean, BodyType.Normal, BodyType.Thick },
                        new List<int> { 25, 25, 25, 25 }),
                    StatsGenerationMedianas = new Dictionary<StatsGroup, float>
                    {
                        { StatsGroup.Speed, 55 }, { StatsGroup.Shooting, 50 }, { StatsGroup.Passing, 55 },
                        { StatsGroup.Technique, 60 }, { StatsGroup.Defending, 40 }, { StatsGroup.Physical, 35 },
                    }
                },
                new PlayerPositionDependentBuilder()
                {
                    PlayerPosition = PlayerPosition.CAM,
                    HeightCreator = new RandomRangesCreator<HeightType>(
                        new List<HeightType> { HeightType.Little, HeightType.Medium, HeightType.UpperMedium, HeightType.Tall },
                        new List<int> { 25, 25, 25, 25 }),
                    BodyCreator = new RandomRangesCreator<BodyType>(
                        new List<BodyType> { BodyType.Lean, BodyType.Normal, BodyType.Thick },
                        new List<int> { 25, 25, 25, 25 }),
                    StatsGenerationMedianas = new Dictionary<StatsGroup, float>
                    {
                        { StatsGroup.Speed, 50 }, { StatsGroup.Shooting, 60 }, { StatsGroup.Passing, 65 },
                        { StatsGroup.Technique, 60 }, { StatsGroup.Defending, 35 }, { StatsGroup.Physical, 35 },
                    }
                },
                new PlayerPositionDependentBuilder()
                {
                    PlayerPosition = PlayerPosition.LF,
                    HeightCreator = new RandomRangesCreator<HeightType>(
                        new List<HeightType> { HeightType.Little, HeightType.Medium, HeightType.UpperMedium, HeightType.Tall },
                        new List<int> { 25, 25, 25, 25 }),
                    BodyCreator = new RandomRangesCreator<BodyType>(
                        new List<BodyType> { BodyType.Lean, BodyType.Normal, BodyType.Thick },
                        new List<int> { 25, 25, 25, 25 }),
                    StatsGenerationMedianas = new Dictionary<StatsGroup, float>
                    {
                        { StatsGroup.Speed, 65 }, { StatsGroup.Shooting, 55 }, { StatsGroup.Passing, 45 },
                        { StatsGroup.Technique, 60 }, { StatsGroup.Defending, 35 }, { StatsGroup.Physical, 35 },
                    }
                },
                new PlayerPositionDependentBuilder()
                {
                    PlayerPosition = PlayerPosition.RF,
                    HeightCreator = new RandomRangesCreator<HeightType>(
                        new List<HeightType> { HeightType.Little, HeightType.Medium, HeightType.UpperMedium, HeightType.Tall },
                        new List<int> { 25, 25, 25, 25 }),
                    BodyCreator = new RandomRangesCreator<BodyType>(
                        new List<BodyType> { BodyType.Lean, BodyType.Normal, BodyType.Thick },
                        new List<int> { 25, 25, 25, 25 }),
                    StatsGenerationMedianas = new Dictionary<StatsGroup, float>
                    {
                        { StatsGroup.Speed, 65 }, { StatsGroup.Shooting, 55 }, { StatsGroup.Passing, 45 },
                        { StatsGroup.Technique, 60 }, { StatsGroup.Defending, 35 }, { StatsGroup.Physical, 35 },
                    }
                },
                new PlayerPositionDependentBuilder()
                {
                    PlayerPosition = PlayerPosition.ST,
                    HeightCreator = new RandomRangesCreator<HeightType>(
                        new List<HeightType> { HeightType.Little, HeightType.Medium, HeightType.UpperMedium, HeightType.Tall },
                        new List<int> { 25, 25, 25, 25 }),
                    BodyCreator = new RandomRangesCreator<BodyType>(
                        new List<BodyType> { BodyType.Lean, BodyType.Normal, BodyType.Thick },
                        new List<int> { 25, 25, 25, 25 }),
                    StatsGenerationMedianas = new Dictionary<StatsGroup, float>
                    {
                        { StatsGroup.Speed, 60 }, { StatsGroup.Shooting, 65 }, { StatsGroup.Passing, 35 },
                        { StatsGroup.Technique, 55 }, { StatsGroup.Defending, 35 }, { StatsGroup.Physical, 50 },
                    }
                },
            };

            #endregion
        }

        public static Player GetPlayer(Club club, FormationPosition formationPosition)
        {
            var player = new Player();

            player.Club = club;
            player.FirstName = NameBuilder.GetFirstName();
            player.LastName = NameBuilder.GetLastName();
            player.Age = GetAge();
            player.Country = Country.England;
            player.FirstPosition = formationPosition.PlayerPosition;

            return player;
        }

        public static PlayerStats GetPlayerStats(Player player)
        {
            var playerStats = new PlayerStats();

            playerStats.Id = player.Id;

            return playerStats;
        }

        public static PlayerTemporaryStats GetPlayerTemporaryStats(Player player)
        {
            var playerTemporaryStats = new PlayerTemporaryStats();

            playerTemporaryStats.Id = player.Id;
            playerTemporaryStats.Stamnia = 100;
            playerTemporaryStats.StamniaDateTime = DateTime.Now;
            playerTemporaryStats.Morale = 50;
            playerTemporaryStats.MoraleDateTime = DateTime.Now;

            return playerTemporaryStats;
        }

        #region Helpers

        public static HeightType GetHeightType(int height)
        {
            if (height < 170) return HeightType.Little;
            else if (height < 180) return HeightType.Medium;
            else if (height < 190) return HeightType.UpperMedium;
            else return HeightType.Tall;
        }

        public static int GetRandomHeight()
        {
            var rnd = new Random();

            return rnd.Next(160, 200);
        }

        public static int GetRandomHeight(HeightType heightType)
        {
            var rnd = new Random();
            switch (heightType)
            {
                case HeightType.Little:
                    return rnd.Next(160, 170);
                case HeightType.Medium:
                    return rnd.Next(170, 180);
                case HeightType.UpperMedium:
                    return rnd.Next(180, 190);
                case HeightType.Tall:
                    return rnd.Next(190, 200);
            }

            throw new Exception("Unable to generate height");
        }

        public static PlayerPositionDependentBuilder GetPositionDependentBuilder(PlayerPosition position)
        {
            return positionDependentBuilders.FirstOrDefault(p => p.PlayerPosition == position);
        }

        #endregion
    }

    public class PlayerPositionDependentBuilder
    {
        public PlayerPosition PlayerPosition { get; set; }

        public RandomRangesCreator<HeightType> HeightCreator { get; set; }

        public RandomRangesCreator<BodyType> BodyCreator { get; set; }

        public Dictionary<StatsGroup, float> StatsGenerationMedianas { get; set; }
    }
}
