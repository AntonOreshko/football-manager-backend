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

        public static List<PlayerLevel> PlayerLevels { get; set; }

        #region random generators

        public static RandomRangesCreator<int> TalentGenerator { get; set; }

        public static RandomRangesCreator<int> AgeGenerator { get; set; }

        #endregion

        #region builders

        private static List<StatsGroupDependentBuilder> statsGroupsDependentBuilders;

        private static List<PlayerPositionDependentBuilder> positionDependentBuilders;

        private static List<ConstitutionDependentBuilder> constitutionDependentBuilders;

        private static List<AgeDependentBuilder> ageDependentBuilders;

        private static List<SpecialtyDependentBuilder> specialtyDependentBuilders;

        #endregion

        static PlayerBuilder()
        {
            PlayerLevels = new List<PlayerLevel>
            {
                new PlayerLevel { Level = 1,  MinOverallRating = 50, MaxOverallRating = 55 },
                new PlayerLevel { Level = 2,  MinOverallRating = 55, MaxOverallRating = 60 },
                new PlayerLevel { Level = 3,  MinOverallRating = 60, MaxOverallRating = 65 },
                new PlayerLevel { Level = 4,  MinOverallRating = 65, MaxOverallRating = 70 },
                new PlayerLevel { Level = 5,  MinOverallRating = 70, MaxOverallRating = 75 },
                new PlayerLevel { Level = 6,  MinOverallRating = 75, MaxOverallRating = 80 },
                new PlayerLevel { Level = 7,  MinOverallRating = 80, MaxOverallRating = 85 },
                new PlayerLevel { Level = 8,  MinOverallRating = 85, MaxOverallRating = 90 },
                new PlayerLevel { Level = 9,  MinOverallRating = 90, MaxOverallRating = 95 },
                new PlayerLevel { Level = 10, MinOverallRating = 95, MaxOverallRating = 100 },
            };

            #region Generators

            TalentGenerator = new RandomRangesCreator<int>(
                new List<int> { 1, 2, 3, 4, 5 },
                new List<int> { 8, 50, 30, 10, 2 });

            AgeGenerator = new RandomRangesCreator<int>(
                new List<int> { 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32 },
                new List<int> { 3,   4,  4,  5,  8,  9, 11, 12, 11,  9,  8,  5,  4,  4,  3 });

            #endregion

            #region Stats group dependent builders

            statsGroupsDependentBuilders = new List<StatsGroupDependentBuilder>
            {
                new StatsGroupDependentBuilder()
                {
                    StatsGroup = StatsGroup.Speed,
                    StatsGroupCoefficients = new Dictionary<string, float>
                    {
                        { ACCELERATION, 0.5f }, { SPRINT_SPEED, 0.5f }
                    }
                },
                new StatsGroupDependentBuilder()
                {
                    StatsGroup = StatsGroup.Shooting,
                    StatsGroupCoefficients = new Dictionary<string, float>
                    {
                        { SHOTS, 0.6f }, { LONG_SHOTS, 0.3f }, { PENALTIES, 0.05f }, { FREE_CICKS, 0.05f }
                    }
                },
                new StatsGroupDependentBuilder()
                {
                    StatsGroup = StatsGroup.Passing,
                    StatsGroupCoefficients = new Dictionary<string, float>
                    {
                        { SHORT_PASSING, 0.50f }, { LONG_PASSING, 0.25f }, { CROSSING, 0.25f }
                    }
                },
                new StatsGroupDependentBuilder()
                {
                    StatsGroup = StatsGroup.Technique,
                    StatsGroupCoefficients = new Dictionary<string, float>
                    {
                        { AGILITY, 0.45f }, { BALL_CONTROL, 0.45f }, { TRICKS, 0.1f }
                    }
                },
                new StatsGroupDependentBuilder()
                {
                    StatsGroup = StatsGroup.Defending,
                    StatsGroupCoefficients = new Dictionary<string, float>
                    {
                        { INTERCEPTIONS, 0.4f }, { STANDING_TACKLES, 0.3f }, { SLIDING_TACKLES, 0.3f }
                    }
                },
                new StatsGroupDependentBuilder()
                {
                    StatsGroup = StatsGroup.Physical,
                    StatsGroupCoefficients = new Dictionary<string, float>
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
                        new List<int> { 5, 45, 45, 5 }),
                    BodyCreator = new RandomRangesCreator<BodyType>(
                        new List<BodyType> { BodyType.Lean, BodyType.Normal, BodyType.Thick },
                        new List<int> { 30, 60, 10 }),
                    StatsGenerationMedianas = new Dictionary<StatsGroup, float>
                    {
                        { StatsGroup.Speed, 50 }, { StatsGroup.Shooting, 35 }, { StatsGroup.Passing, 40 },
                        { StatsGroup.Technique, 45 }, { StatsGroup.Defending, 65 }, { StatsGroup.Physical, 55 },
                    },
                    StatsOverallCoefficients = new Dictionary<string, float>
                    {
                        { ACCELERATION, 0.1f }, { SPRINT_SPEED, 0.1f },
                        { SHOTS, 0.01f }, { LONG_SHOTS, 0.01f }, { PENALTIES, 0.005f }, { FREE_CICKS, 0.005f },
                        { CROSSING, 0.05f }, { SHORT_PASSING, 0.04f }, { LONG_PASSING, 0.04f },
                        { AGILITY, 0.04f }, { BALL_CONTROL, 0.04f }, { TRICKS, 0.005f },
                        { INTERCEPTIONS, 0.125f }, { STANDING_TACKLES, 0.08f }, { SLIDING_TACKLES, 0.09f },
                        { JUMPING, 0.08f }, { STRENGTH, 0.05f }, { HEADING, 0.05f }, { STAMINA, 0.08f },
                    }
                },
                new PlayerPositionDependentBuilder()
                {
                    PlayerPosition = PlayerPosition.RB,
                    HeightCreator = new RandomRangesCreator<HeightType>(
                        new List<HeightType> { HeightType.Little, HeightType.Medium, HeightType.UpperMedium, HeightType.Tall },
                        new List<int> { 5, 45, 45, 5 }),
                    BodyCreator = new RandomRangesCreator<BodyType>(
                        new List<BodyType> { BodyType.Lean, BodyType.Normal, BodyType.Thick },
                        new List<int> { 30, 60, 10 }),
                    StatsGenerationMedianas = new Dictionary<StatsGroup, float>
                    {
                        { StatsGroup.Speed, 50 }, { StatsGroup.Shooting, 35 }, { StatsGroup.Passing, 40 },
                        { StatsGroup.Technique, 45 }, { StatsGroup.Defending, 65 }, { StatsGroup.Physical, 55 },
                    },
                    StatsOverallCoefficients = new Dictionary<string, float>
                    {
                        { ACCELERATION, 0.1f }, { SPRINT_SPEED, 0.1f },
                        { SHOTS, 0.01f }, { LONG_SHOTS, 0.01f }, { PENALTIES, 0.005f }, { FREE_CICKS, 0.005f },
                        { CROSSING, 0.05f }, { SHORT_PASSING, 0.04f }, { LONG_PASSING, 0.04f },
                        { AGILITY, 0.04f }, { BALL_CONTROL, 0.04f }, { TRICKS, 0.005f },
                        { INTERCEPTIONS, 0.125f }, { STANDING_TACKLES, 0.08f }, { SLIDING_TACKLES, 0.09f },
                        { JUMPING, 0.08f }, { STRENGTH, 0.05f }, { HEADING, 0.05f }, { STAMINA, 0.08f },
                    }
                },
                new PlayerPositionDependentBuilder()
                {
                    PlayerPosition = PlayerPosition.CB,
                    HeightCreator = new RandomRangesCreator<HeightType>(
                        new List<HeightType> { HeightType.Little, HeightType.Medium, HeightType.UpperMedium, HeightType.Tall },
                        new List<int> { 0, 30, 60, 10 }),
                    BodyCreator = new RandomRangesCreator<BodyType>(
                        new List<BodyType> { BodyType.Lean, BodyType.Normal, BodyType.Thick },
                        new List<int> { 15, 55, 30 }),
                    StatsGenerationMedianas = new Dictionary<StatsGroup, float>
                    {
                        { StatsGroup.Speed, 45 }, { StatsGroup.Shooting, 35 }, { StatsGroup.Passing, 35 },
                        { StatsGroup.Technique, 35 }, { StatsGroup.Defending, 65 }, { StatsGroup.Physical, 65 },
                    },
                    StatsOverallCoefficients = new Dictionary<string, float>
                    {
                        { ACCELERATION, 0.08f }, { SPRINT_SPEED, 0.08f },
                        { SHOTS, 0.01f }, { LONG_SHOTS, 0.01f }, { PENALTIES, 0.005f }, { FREE_CICKS, 0.005f },
                        { CROSSING, 0.01f }, { SHORT_PASSING, 0.04f }, { LONG_PASSING, 0.04f },
                        { AGILITY, 0.03f }, { BALL_CONTROL, 0.03f }, { TRICKS, 0.05f },
                        { INTERCEPTIONS, 0.145f }, { STANDING_TACKLES, 0.1f }, { SLIDING_TACKLES, 0.1f },
                        { JUMPING, 0.09f }, { STRENGTH, 0.08f }, { HEADING, 0.07f }, { STAMINA, 0.07f },
                    }
                },
                new PlayerPositionDependentBuilder()
                {
                    PlayerPosition = PlayerPosition.CDM,
                    HeightCreator = new RandomRangesCreator<HeightType>(
                        new List<HeightType> { HeightType.Little, HeightType.Medium, HeightType.UpperMedium, HeightType.Tall },
                        new List<int> { 5, 45, 45, 5 }),
                    BodyCreator = new RandomRangesCreator<BodyType>(
                        new List<BodyType> { BodyType.Lean, BodyType.Normal, BodyType.Thick },
                        new List<int> { 10, 70, 20 }),
                    StatsGenerationMedianas = new Dictionary<StatsGroup, float>
                    {
                        { StatsGroup.Speed, 40 }, { StatsGroup.Shooting, 45 }, { StatsGroup.Passing, 55 },
                        { StatsGroup.Technique, 40 }, { StatsGroup.Defending, 55 }, { StatsGroup.Physical, 55 },
                    },
                    StatsOverallCoefficients = new Dictionary<string, float>
                    {
                        { ACCELERATION, 0.06f }, { SPRINT_SPEED, 0.06f },
                        { SHOTS, 0.02f }, { LONG_SHOTS, 0.02f }, { PENALTIES, 0.005f }, { FREE_CICKS, 0.005f },
                        { CROSSING, 0.02f }, { SHORT_PASSING, 0.1f }, { LONG_PASSING, 0.08f },
                        { AGILITY, 0.03f }, { BALL_CONTROL, 0.05f }, { TRICKS, 0.005f },
                        { INTERCEPTIONS, 0.11f }, { STANDING_TACKLES, 0.085f }, { SLIDING_TACKLES, 0.09f },
                        { JUMPING, 0.08f }, { STRENGTH, 0.07f }, { HEADING, 0.05f }, { STAMINA, 0.06f },
                    }
                },
                new PlayerPositionDependentBuilder()
                {
                    PlayerPosition = PlayerPosition.CM,
                    HeightCreator = new RandomRangesCreator<HeightType>(
                        new List<HeightType> { HeightType.Little, HeightType.Medium, HeightType.UpperMedium, HeightType.Tall },
                        new List<int> { 5, 45, 45, 5 }),
                    BodyCreator = new RandomRangesCreator<BodyType>(
                        new List<BodyType> { BodyType.Lean, BodyType.Normal, BodyType.Thick },
                        new List<int> { 25, 60, 15 }),
                    StatsGenerationMedianas = new Dictionary<StatsGroup, float>
                    {
                        { StatsGroup.Speed, 40 }, { StatsGroup.Shooting, 50 }, { StatsGroup.Passing, 65 },
                        { StatsGroup.Technique, 55 }, { StatsGroup.Defending, 45 }, { StatsGroup.Physical, 45 },
                    },
                    StatsOverallCoefficients = new Dictionary<string, float>
                    {
                        { ACCELERATION, 0.05f }, { SPRINT_SPEED, 0.04f },
                        { SHOTS, 0.04f }, { LONG_SHOTS, 0.04f }, { PENALTIES, 0.005f }, { FREE_CICKS, 0.005f },
                        { CROSSING, 0.02f }, { SHORT_PASSING, 0.15f }, { LONG_PASSING, 0.125f },
                        { AGILITY, 0.05f }, { BALL_CONTROL, 0.08f }, { TRICKS, 0.005f },
                        { INTERCEPTIONS, 0.07f }, { STANDING_TACKLES, 0.05f }, { SLIDING_TACKLES, 0.04f },
                        { JUMPING, 0.05f }, { STRENGTH, 0.06f }, { HEADING, 0.05f }, { STAMINA, 0.07f },
                    }
                },
                new PlayerPositionDependentBuilder()
                {
                    PlayerPosition = PlayerPosition.LM,
                    HeightCreator = new RandomRangesCreator<HeightType>(
                        new List<HeightType> { HeightType.Little, HeightType.Medium, HeightType.UpperMedium, HeightType.Tall },
                        new List<int> { 10, 50, 35, 5 }),
                    BodyCreator = new RandomRangesCreator<BodyType>(
                        new List<BodyType> { BodyType.Lean, BodyType.Normal, BodyType.Thick },
                        new List<int> { 20, 70, 10 }),
                    StatsGenerationMedianas = new Dictionary<StatsGroup, float>
                    {
                        { StatsGroup.Speed, 55 }, { StatsGroup.Shooting, 50 }, { StatsGroup.Passing, 55 },
                        { StatsGroup.Technique, 60 }, { StatsGroup.Defending, 40 }, { StatsGroup.Physical, 35 },
                    },
                    StatsOverallCoefficients = new Dictionary<string, float>
                    {
                        { ACCELERATION, 0.1f }, { SPRINT_SPEED, 0.1f },
                        { SHOTS, 0.03f }, { LONG_SHOTS, 0.03f }, { PENALTIES, 0.005f }, { FREE_CICKS, 0.005f },
                        { CROSSING, 0.05f }, { SHORT_PASSING, 0.08f }, { LONG_PASSING, 0.08f },
                        { AGILITY, 0.1f }, { BALL_CONTROL, 0.1f }, { TRICKS, 0.05f },
                        { INTERCEPTIONS, 0.05f }, { STANDING_TACKLES, 0.015f }, { SLIDING_TACKLES, 0.02f },
                        { JUMPING, 0.05f }, { STRENGTH, 0.04f }, { HEADING, 0.05f }, { STAMINA, 0.09f },
                    }
                },
                new PlayerPositionDependentBuilder()
                {
                    PlayerPosition = PlayerPosition.RM,
                    HeightCreator = new RandomRangesCreator<HeightType>(
                        new List<HeightType> { HeightType.Little, HeightType.Medium, HeightType.UpperMedium, HeightType.Tall },
                        new List<int> { 10, 50, 35, 5 }),
                    BodyCreator = new RandomRangesCreator<BodyType>(
                        new List<BodyType> { BodyType.Lean, BodyType.Normal, BodyType.Thick },
                        new List<int> { 20, 70, 10 }),
                    StatsGenerationMedianas = new Dictionary<StatsGroup, float>
                    {
                        { StatsGroup.Speed, 55 }, { StatsGroup.Shooting, 50 }, { StatsGroup.Passing, 55 },
                        { StatsGroup.Technique, 60 }, { StatsGroup.Defending, 40 }, { StatsGroup.Physical, 35 },
                    },
                    StatsOverallCoefficients = new Dictionary<string, float>
                    {
                        { ACCELERATION, 0.1f }, { SPRINT_SPEED, 0.1f },
                        { SHOTS, 0.03f }, { LONG_SHOTS, 0.03f }, { PENALTIES, 0.005f }, { FREE_CICKS, 0.005f },
                        { CROSSING, 0.05f }, { SHORT_PASSING, 0.08f }, { LONG_PASSING, 0.08f },
                        { AGILITY, 0.1f }, { BALL_CONTROL, 0.1f }, { TRICKS, 0.05f },
                        { INTERCEPTIONS, 0.05f }, { STANDING_TACKLES, 0.015f }, { SLIDING_TACKLES, 0.02f },
                        { JUMPING, 0.05f }, { STRENGTH, 0.04f }, { HEADING, 0.05f }, { STAMINA, 0.09f },
                    }
                },
                new PlayerPositionDependentBuilder()
                {
                    PlayerPosition = PlayerPosition.CAM,
                    HeightCreator = new RandomRangesCreator<HeightType>(
                        new List<HeightType> { HeightType.Little, HeightType.Medium, HeightType.UpperMedium, HeightType.Tall },
                        new List<int> { 15, 50, 30, 5 }),
                    BodyCreator = new RandomRangesCreator<BodyType>(
                        new List<BodyType> { BodyType.Lean, BodyType.Normal, BodyType.Thick },
                        new List<int> { 20, 70, 10 }),
                    StatsGenerationMedianas = new Dictionary<StatsGroup, float>
                    {
                        { StatsGroup.Speed, 50 }, { StatsGroup.Shooting, 60 }, { StatsGroup.Passing, 65 },
                        { StatsGroup.Technique, 60 }, { StatsGroup.Defending, 35 }, { StatsGroup.Physical, 35 },
                    },
                    StatsOverallCoefficients = new Dictionary<string, float>
                    {
                        { ACCELERATION, 0.08f }, { SPRINT_SPEED, 0.08f },
                        { SHOTS, 0.1f }, { LONG_SHOTS, 0.1f }, { PENALTIES, 0.005f }, { FREE_CICKS, 0.005f },
                        { CROSSING, 0.02f }, { SHORT_PASSING, 0.12f }, { LONG_PASSING, 0.07f },
                        { AGILITY, 0.1f }, { BALL_CONTROL, 0.1f }, { TRICKS, 0.005f },
                        { INTERCEPTIONS, 0.025f }, { STANDING_TACKLES, 0.01f }, { SLIDING_TACKLES, 0.01f },
                        { JUMPING, 0.03f }, { STRENGTH, 0.03f }, { HEADING, 0.003f }, { STAMINA, 0.08f },
                    }
                },
                new PlayerPositionDependentBuilder()
                {
                    PlayerPosition = PlayerPosition.LF,
                    HeightCreator = new RandomRangesCreator<HeightType>(
                        new List<HeightType> { HeightType.Little, HeightType.Medium, HeightType.UpperMedium, HeightType.Tall },
                        new List<int> { 15, 50, 30, 5 }),
                    BodyCreator = new RandomRangesCreator<BodyType>(
                        new List<BodyType> { BodyType.Lean, BodyType.Normal, BodyType.Thick },
                        new List<int> { 30, 65, 5 }),
                    StatsGenerationMedianas = new Dictionary<StatsGroup, float>
                    {
                        { StatsGroup.Speed, 65 }, { StatsGroup.Shooting, 55 }, { StatsGroup.Passing, 45 },
                        { StatsGroup.Technique, 60 }, { StatsGroup.Defending, 35 }, { StatsGroup.Physical, 35 },
                    },
                    StatsOverallCoefficients = new Dictionary<string, float>
                    {
                        { ACCELERATION, 0.1f }, { SPRINT_SPEED, 0.1f },
                        { SHOTS, 0.11f }, { LONG_SHOTS, 0.05f }, { PENALTIES, 0.005f }, { FREE_CICKS, 0.005f },
                        { CROSSING, 0.05f }, { SHORT_PASSING, 0.07f }, { LONG_PASSING, 0.03f },
                        { AGILITY, 0.12f }, { BALL_CONTROL, 0.12f }, { TRICKS, 0.05f },
                        { INTERCEPTIONS, 0.015f }, { STANDING_TACKLES, 0.01f }, { SLIDING_TACKLES, 0.01f },
                        { JUMPING, 0.03f }, { STRENGTH, 0.04f }, { HEADING, 0.03f }, { STAMINA, 0.1f },
                    }
                },
                new PlayerPositionDependentBuilder()
                {
                    PlayerPosition = PlayerPosition.RF,
                    HeightCreator = new RandomRangesCreator<HeightType>(
                        new List<HeightType> { HeightType.Little, HeightType.Medium, HeightType.UpperMedium, HeightType.Tall },
                        new List<int> { 15, 50, 30, 5 }),
                    BodyCreator = new RandomRangesCreator<BodyType>(
                        new List<BodyType> { BodyType.Lean, BodyType.Normal, BodyType.Thick },
                        new List<int> { 30, 65, 5 }),
                    StatsGenerationMedianas = new Dictionary<StatsGroup, float>
                    {
                        { StatsGroup.Speed, 65 }, { StatsGroup.Shooting, 55 }, { StatsGroup.Passing, 45 },
                        { StatsGroup.Technique, 60 }, { StatsGroup.Defending, 35 }, { StatsGroup.Physical, 35 },
                    },
                    StatsOverallCoefficients = new Dictionary<string, float>
                    {
                        { ACCELERATION, 0.1f }, { SPRINT_SPEED, 0.1f },
                        { SHOTS, 0.11f }, { LONG_SHOTS, 0.05f }, { PENALTIES, 0.005f }, { FREE_CICKS, 0.005f },
                        { CROSSING, 0.05f }, { SHORT_PASSING, 0.07f }, { LONG_PASSING, 0.03f },
                        { AGILITY, 0.12f }, { BALL_CONTROL, 0.12f }, { TRICKS, 0.05f },
                        { INTERCEPTIONS, 0.015f }, { STANDING_TACKLES, 0.01f }, { SLIDING_TACKLES, 0.01f },
                        { JUMPING, 0.03f }, { STRENGTH, 0.04f }, { HEADING, 0.03f }, { STAMINA, 0.1f },
                    }
                },
                new PlayerPositionDependentBuilder()
                {
                    PlayerPosition = PlayerPosition.ST,
                    HeightCreator = new RandomRangesCreator<HeightType>(
                        new List<HeightType> { HeightType.Little, HeightType.Medium, HeightType.UpperMedium, HeightType.Tall },
                        new List<int> { 5, 45, 40, 10 }),
                    BodyCreator = new RandomRangesCreator<BodyType>(
                        new List<BodyType> { BodyType.Lean, BodyType.Normal, BodyType.Thick },
                        new List<int> { 30, 55, 15 }),
                    StatsGenerationMedianas = new Dictionary<StatsGroup, float>
                    {
                        { StatsGroup.Speed, 60 }, { StatsGroup.Shooting, 65 }, { StatsGroup.Passing, 35 },
                        { StatsGroup.Technique, 55 }, { StatsGroup.Defending, 35 }, { StatsGroup.Physical, 50 },
                    },
                    StatsOverallCoefficients = new Dictionary<string, float>
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

            #endregion

            #region Constitution dependent builders

            constitutionDependentBuilders = new List<ConstitutionDependentBuilder>
            {
                new ConstitutionDependentBuilder
                {
                    HeightType = HeightType.Little, BodyType = BodyType.Lean,
                    StatsBoosters = new Dictionary<string, int>
                    {
                        { ACCELERATION, 2 }, { SPRINT_SPEED, 2 }, { AGILITY, 2 }, { TRICKS, 2 }, { JUMPING, 2 }, { STRENGTH, -3 },
                        { HEADING, -3 }, { STAMINA, 2 }, { INTERCEPTIONS, -2 }, { STANDING_TACKLES, -2 }, { SLIDING_TACKLES, -2 }
                    }
                },
                new ConstitutionDependentBuilder
                {
                    HeightType = HeightType.Little, BodyType = BodyType.Normal,
                    StatsBoosters = new Dictionary<string, int>
                    {
                        { ACCELERATION, 1 }, { SPRINT_SPEED, 1 }, { AGILITY, 1 }, { TRICKS, 1 }, { JUMPING, 1 }, { STRENGTH, -2 },
                        { HEADING, -2 }, { STAMINA, 1 }, { INTERCEPTIONS, -1 }, { STANDING_TACKLES, -1 }, { SLIDING_TACKLES, -1 }
                    }
                },
                new ConstitutionDependentBuilder
                {
                    HeightType = HeightType.Little, BodyType = BodyType.Thick,
                    StatsBoosters = new Dictionary<string, int>
                    {
                        { STRENGTH, -1 }, { HEADING, -1 },
                    }
                },
                new ConstitutionDependentBuilder
                {
                    HeightType = HeightType.Medium, BodyType = BodyType.Lean,
                    StatsBoosters = new Dictionary<string, int>
                    {
                        { ACCELERATION, 1 }, { SPRINT_SPEED, 1 }, { AGILITY, 1 }, { TRICKS, 1 }, { JUMPING, 1 }, { STRENGTH, -2 },
                        { HEADING, -2 }, { STAMINA, 1 }, { INTERCEPTIONS, -1 }, { STANDING_TACKLES, -1 }, { SLIDING_TACKLES, -1 }
                    }
                },
                new ConstitutionDependentBuilder
                {
                    HeightType = HeightType.Medium, BodyType = BodyType.Normal,
                    StatsBoosters = new Dictionary<string, int>
                    {
                        { STRENGTH, -1 }, { HEADING, -1 },
                    }
                },
                new ConstitutionDependentBuilder
                {
                    HeightType = HeightType.Medium, BodyType = BodyType.Thick,
                    StatsBoosters = new Dictionary<string, int>
                    {
                    }
                },
                new ConstitutionDependentBuilder
                {
                    HeightType = HeightType.UpperMedium, BodyType = BodyType.Lean,
                    StatsBoosters = new Dictionary<string, int>
                    {
                    }
                },
                new ConstitutionDependentBuilder
                {
                    HeightType = HeightType.UpperMedium, BodyType = BodyType.Normal,
                    StatsBoosters = new Dictionary<string, int>
                    {
                        { STRENGTH, 1 }, { HEADING, 1 },
                    }
                },
                new ConstitutionDependentBuilder
                {
                    HeightType = HeightType.UpperMedium, BodyType = BodyType.Thick,
                    StatsBoosters = new Dictionary<string, int>
                    {
                        { ACCELERATION, -1 }, { SPRINT_SPEED, -1 }, { AGILITY, -1 }, { TRICKS, -1 }, { JUMPING, -1 }, { STRENGTH, 2 },
                        { HEADING, 2 }, { STAMINA, -1 }, { INTERCEPTIONS, 1 }, { STANDING_TACKLES, 1 }, { SLIDING_TACKLES, 1 }
                    }
                },
                new ConstitutionDependentBuilder
                {
                    HeightType = HeightType.Tall, BodyType = BodyType.Lean,
                    StatsBoosters = new Dictionary<string, int>
                    {
                        { STRENGTH, 1 }, { HEADING, 1 },
                    }
                },
                new ConstitutionDependentBuilder
                {
                    HeightType = HeightType.Tall, BodyType = BodyType.Normal,
                    StatsBoosters = new Dictionary<string, int>
                    {
                        { ACCELERATION, -1 }, { SPRINT_SPEED, -1 }, { AGILITY, -1 }, { TRICKS, -1 }, { JUMPING, -1 }, { STRENGTH, 2 },
                        { HEADING, 2 }, { STAMINA, -1 }, { INTERCEPTIONS, 1 }, { STANDING_TACKLES, 1 }, { SLIDING_TACKLES, 1 }
                    }
                },
                new ConstitutionDependentBuilder
                {
                    HeightType = HeightType.Tall, BodyType = BodyType.Thick,
                    StatsBoosters = new Dictionary<string, int>
                    {
                        { ACCELERATION, -2 }, { SPRINT_SPEED, -2 }, { AGILITY, -2 }, { TRICKS, -2 }, { JUMPING, -2 }, { STRENGTH, 3 },
                        { HEADING, 3 }, { STAMINA, -2 }, { INTERCEPTIONS, 2 }, { STANDING_TACKLES, 2 }, { SLIDING_TACKLES, 2 }
                    }
                },
            };

            #endregion

            #region Age dependent builders

            // TODO
            ageDependentBuilders = new List<AgeDependentBuilder>
            {
                new AgeDependentBuilder
                {
                    Age = 31, StopCarreerPossibility = 0, 
                    StatsBoosters = new Dictionary<string, int>
                    {

                    }
                }
            };

            #endregion

            #region Specialty dependent builders

            specialtyDependentBuilders = new List<SpecialtyDependentBuilder>
            {
                new SpecialtyDependentBuilder
                {
                    Specialty = PlayerSpecialty.Blizzard,
                    StatsBoosters = new Dictionary<string, int>
                    {
                        { ACCELERATION , 2 }, { SPRINT_SPEED, 2 }
                    }
                },
                new SpecialtyDependentBuilder
                {
                    Specialty = PlayerSpecialty.Killer,
                    StatsBoosters = new Dictionary<string, int>
                    {
                        { SHOTS , 2 }, { HEADING, 2 }
                    }
                },
                new SpecialtyDependentBuilder
                {
                    Specialty = PlayerSpecialty.Sniper,
                    StatsBoosters = new Dictionary<string, int>
                    {
                        { FREE_CICKS , 2 }, { PENALTIES, 2 }
                    }
                },
                new SpecialtyDependentBuilder
                {
                    Specialty = PlayerSpecialty.Dispatcher,
                    StatsBoosters = new Dictionary<string, int>
                    {
                        { SHORT_PASSING , 2 }, { LONG_PASSING, 2 }
                    }
                },
                new SpecialtyDependentBuilder
                {
                    Specialty = PlayerSpecialty.Panzer,
                    StatsBoosters = new Dictionary<string, int>
                    {
                        { LONG_SHOTS , 2 }, { STRENGTH, 2 }
                    }
                },
                new SpecialtyDependentBuilder
                {
                    Specialty = PlayerSpecialty.Engine,
                    StatsBoosters = new Dictionary<string, int>
                    {
                        { STAMINA , 2 }, { JUMPING, 2 }
                    }
                },
                new SpecialtyDependentBuilder
                {
                    Specialty = PlayerSpecialty.Dribbler,
                    StatsBoosters = new Dictionary<string, int>
                    {
                        { AGILITY , 2 }, { BALL_CONTROL, 2 }
                    }
                },
                new SpecialtyDependentBuilder
                {
                    Specialty = PlayerSpecialty.Wall,
                    StatsBoosters = new Dictionary<string, int>
                    {
                        { INTERCEPTIONS , 2 }, { STANDING_TACKLES, 2 }
                    }
                },
            };

            #endregion
        }

        public static Player CreatePlayer(Club club, FormationPosition formationPosition, int level)
        {
            var player = new Player();

            player.Club = club;
            player.FirstName = NameBuilder.GetFirstName();
            player.LastName = NameBuilder.GetLastName();
            player.Country = Country.England;
            player.FirstPosition = formationPosition.PlayerPosition;

            if (player.FirstPosition != PlayerPosition.GK)
            {
                var positionDependentBuilder = GetPositionDependentBuilder(player.FirstPosition);

                player.HeightType = positionDependentBuilder.HeightCreator.GetRandom();
                player.BodyType = positionDependentBuilder.BodyCreator.GetRandom();

                player.Height = GetRandomHeight(player.HeightType);
                player.Weight = (int)((player.Height * player.Height) * GetRandomBodyMassIndex(player.BodyType) / 10000.0f);

                player.Age = AgeGenerator.GetRandom();
                player.Talent = TalentGenerator.GetRandom();

                var playerStats = new PlayerStats();
                playerStats.Id = player.Id;

                positionDependentBuilder.GenerateStats(playerStats);

                var overallRating = positionDependentBuilder.GetOverallRating(playerStats);
                var wantedOverallRating = GetPlayerLevel(level).GetRandomRating();

                player.Stats = playerStats;
            }

            return player;
        }

        public static PlayerStats GetPlayerStats(Player player )
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

        public static PlayerLevel GetPlayerLevel(int level)
        {
            return PlayerLevels.FirstOrDefault(pl => pl.Level == level);
        }

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

        public static float GetRandomBodyMassIndex(BodyType bodyType)
        {
            var rnd = new Random();
            switch (bodyType)
            {
                case BodyType.Lean:
                    return rnd.Next(1900, 2200) / 100.0f;
                case BodyType.Normal:
                    return rnd.Next(2200, 2500) / 100.0f;
                case BodyType.Thick:
                    return rnd.Next(2500, 2800) / 100.0f;
            }

            throw new Exception("Unable to generate body mass index");
        }

        public static StatsGroup GetStatGroup(string stat)
        {
            switch (stat)
            {
                case ACCELERATION:
                case SPRINT_SPEED:
                    return StatsGroup.Speed;
                case SHOTS:
                case LONG_SHOTS:
                case FREE_CICKS:
                case PENALTIES:
                    return StatsGroup.Shooting;
                case SHORT_PASSING:
                case LONG_PASSING:
                case CROSSING:
                    return StatsGroup.Passing;
                case BALL_CONTROL:
                case AGILITY:
                case TRICKS:
                    return StatsGroup.Technique;
                case INTERCEPTIONS:
                case STANDING_TACKLES:
                case SLIDING_TACKLES:
                    return StatsGroup.Defending;
                case JUMPING:
                case STRENGTH:
                case HEADING:
                case STAMINA:
                    return StatsGroup.Physical;

            }

            throw new Exception("Can't find stat group");
        }

        public static PlayerPositionDependentBuilder GetPositionDependentBuilder(PlayerPosition position)
        {
            return positionDependentBuilders.FirstOrDefault(p => p.PlayerPosition == position);
        }

        public static StatsGroupDependentBuilder GetStatsGroupDependentBuilder(StatsGroup statsGroup)
        {
            return statsGroupsDependentBuilders.FirstOrDefault(p => p.StatsGroup == statsGroup);
        }

        public static ConstitutionDependentBuilder GetConstitutionDependentBuilder(HeightType heighType, BodyType bodyType)
        {
            return constitutionDependentBuilders.FirstOrDefault(cdb => cdb.HeightType == heighType && cdb.BodyType == bodyType);
        }

        public static float GetStatsGroupRating(StatsGroup statsGroup, PlayerStats stats)
        {
            var statsGroupDependentBuilder = GetStatsGroupDependentBuilder(statsGroup);

            return statsGroupDependentBuilder.GetStatsGroupRating(stats);
        }

        public static float GetOverallRating(PlayerPosition position, PlayerStats stats)
        {
            var positionDependentBuilder = GetPositionDependentBuilder(position);

            return positionDependentBuilder.GetOverallRating(stats);
        }

        #endregion
    }

    public class StatsGroupDependentBuilder
    {
        public StatsGroup StatsGroup { get; set; }

        public Dictionary<string, float> StatsGroupCoefficients { get; set; }

        public float GetStatsGroupRating(PlayerStats stats)
        {
            var rating = 0.0f;
            foreach(var s in StatsGroupCoefficients)
            {
                rating += s.Value * stats.GetValue(s.Key);
            }
            return rating;
        }
    }

    public class PlayerPositionDependentBuilder
    {
        public static int StatsGenerationDelta = 10;

        public PlayerPosition PlayerPosition { get; set; }

        public RandomRangesCreator<HeightType> HeightCreator { get; set; }

        public RandomRangesCreator<BodyType> BodyCreator { get; set; }

        public Dictionary<StatsGroup, float> StatsGenerationMedianas { get; set; }

        public Dictionary<string, float> StatsOverallCoefficients { get; set; }

        public void GenerateStats(PlayerStats stats)
        {
            var rnd = new Random();

            foreach (var stat in stats.Stats)
            {
                var statsGroup = PlayerBuilder.GetStatGroup(stat.Name);

                var mediana = StatsGenerationMedianas[statsGroup];

                var statValue = mediana + rnd.Next(-StatsGenerationDelta, StatsGenerationDelta + 1);

                stat.Value = statValue;
            }
        }

        public float GetOverallRating(PlayerStats stats)
        {
            var overallRating = 0.0f;

            foreach(var stat in stats.Stats)
            {
                overallRating += stat.Value * StatsOverallCoefficients[stat.Name];
            }

            return overallRating;
        }

        public void UpdatePlayerStats(PlayerStats stats, float overallRating, float wantedRating)
        {
            foreach (var stat in stats.Stats)
            {
                stat.Value *= wantedRating / overallRating;

                if (stat.Value > 100.0f) stat.Value = 100.0f;
            }
        }
    }

    public class ConstitutionDependentBuilder
    {
        public static float BoostValue = 2.5f;

        public HeightType HeightType { get; set; }

        public BodyType BodyType { get; set; }

        public Dictionary<string, int> StatsBoosters { get; set; }
    }

    public class AgeDependentBuilder
    {
        public static float BoostValue = -2.5f;

        public int Age { get; set; }

        public float StopCarreerPossibility { get; set; }

        public Dictionary<string, int> StatsBoosters { get; set; }
    }

    public class SpecialtyDependentBuilder
    {
        public static float BoostValue = 4.0f;

        public PlayerSpecialty Specialty { get; set; }

        public Dictionary<string, int> StatsBoosters { get; set; }
    }

    public class PlayerLevel
    {
        public int Level { get; set; }

        public int MinOverallRating { get; set; }

        public int MaxOverallRating { get; set; }

        public int GetRandomRating()
        {
            var rnd = new Random();

            return rnd.Next(MinOverallRating, MaxOverallRating);
        }
    }
}
