using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLayer.Builders.BuildersData;
using BusinessLayer.Builders.UtilityBuilder;
using BusinessLayer.Mappers;
using BusinessLayer.Wrappers;
using DomainModels.Enums;
using DomainModels.Models.PlayerEntities;
using Utility;
using Utility.Helpers;

namespace BusinessLayer.Builders
{
    public static class PlayerBuilder
    {
        private static readonly AgeMapper AgeMapper;

        private static readonly ConstitutionMapper ConstitutionMapper;

        private static readonly PlayerLevelMapper PlayerLevelMapper;

        private static readonly PlayerPositionMapper PlayerPositionMapper;

        private static readonly StatsGroupMapper StatsGroupMapper;

        private static readonly TalentMapper TalentMapper;

        private static RandomRangesCreator<int> TalentGenerator { get; }

        private static RandomRangesCreator<int> AgeGenerator { get; }

        private static Dictionary<PlayerPosition, RandomRangesCreator<HeightType>> HeightTypeCreators { get; }

        private static Dictionary<PlayerPosition, RandomRangesCreator<BodyType>> BodyTypeCreators { get; }

        static PlayerBuilder()
        {
            AgeMapper = ConfigBuilder.GetConfig<AgeMapper>().Get();
            ConstitutionMapper = ConfigBuilder.GetConfig<ConstitutionMapper>().Get();
            PlayerLevelMapper = ConfigBuilder.GetConfig<PlayerLevelMapper>().Get();
            PlayerPositionMapper = ConfigBuilder.GetConfig<PlayerPositionMapper>().Get();
            StatsGroupMapper = ConfigBuilder.GetConfig<StatsGroupMapper>().Get();
            TalentMapper = ConfigBuilder.GetConfig<TalentMapper>().Get();

            TalentGenerator = new RandomRangesCreator<int>(TalentMapper.Talent, TalentMapper.Percents);
            AgeGenerator = new RandomRangesCreator<int>(AgeMapper.Age, AgeMapper.Percents);

            HeightTypeCreators = new Dictionary<PlayerPosition, RandomRangesCreator<HeightType>>();
            BodyTypeCreators = new Dictionary<PlayerPosition, RandomRangesCreator<BodyType>>();

            foreach (var item in PlayerPositionMapper.Items)
            {
                var heightTypes = typeof(HeightType).ToList<HeightType>();
                var bodyTypes = typeof(BodyType).ToList<BodyType>();
                var heightPercents = new List<int>();
                var bodyPercents = new List<int>();
                foreach (var ht in heightTypes)
                {
                    heightPercents.Add(item.HeighTypePercents[ht]);
                }
                foreach (var bt in bodyTypes)
                {
                    bodyPercents.Add(item.BodyTypePercents[bt]);
                }
                HeightTypeCreators.Add(item.PlayerPosition, 
                    new RandomRangesCreator<HeightType>(heightTypes, heightPercents));
                BodyTypeCreators.Add(item.PlayerPosition,
                    new RandomRangesCreator<BodyType>(bodyTypes, bodyPercents));
            }
        }

        public static Player Get(IPlayerBuilderData playerBuilderData)
        {
            var player = new Player
            {
                Country = playerBuilderData.Country,
                Position = playerBuilderData.Position
            };

            PersonBuilder.SetPerson(player);

            var playerPositionMapper = PlayerPositionMapper.Items.First(i => i.PlayerPosition == player.Position);

            player.HeightType = HeightTypeCreators[player.Position].GetRandom();
            player.BodyType = BodyTypeCreators[player.Position].GetRandom();

            player.Height = GetRandomHeight(player.HeightType);
            player.Weight = (int)((player.Height * player.Height) * GetRandomBodyMassIndex(player.BodyType) / 10000.0f);

            player.Age = AgeGenerator.GetRandom();
            player.Talent = TalentGenerator.GetRandom();

            var stats = new PlayerStats();
            var statsWrapper = new PlayerStatsWrapper(stats);

            GenerateStats(statsWrapper, playerPositionMapper);

            var overallRating = GetOverallRating(statsWrapper, playerPositionMapper);
            var wantedOverallRating = GetPlayerLevel(playerBuilderData.Level);

            UpdatePlayerStats(statsWrapper, overallRating, wantedOverallRating);

            player.Stats = stats;

            return player;
        }

        private static int GetRandomHeight(HeightType heightType)
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

        private static float GetRandomBodyMassIndex(BodyType bodyType)
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

        private static void GenerateStats(PlayerStatsWrapper stats, PlayerPositionItem playerPositionMapper)
        {
            var rnd = new Random();

            foreach (var stat in stats.Stats)
            {
                var statsGroup = GetStatGroup(stat.Name);

                var mediana = playerPositionMapper.StatsGenerationMedianas[statsGroup];

                float statValue = 0;

                if (mediana > 0)
                {
                    statValue = mediana + rnd.Next(-playerPositionMapper.StatsGenerationDelta, playerPositionMapper.StatsGenerationDelta + 1);
                }

                stat.Value = statValue;
            }
        }

        private static float GetOverallRating(PlayerStatsWrapper stats, PlayerPositionItem playerPositionMapper)
        {
            var overallRating = 0.0f;

            foreach (var stat in stats.Stats)
            {
                overallRating += stat.Value * playerPositionMapper.StatsOverallCoefficients[stat.Name];
            }

            return overallRating;
        }

        private static void UpdatePlayerStats(PlayerStatsWrapper stats, float overallRating, float wantedRating)
        {
            foreach (var stat in stats.Stats)
            {
                stat.Value *= wantedRating / overallRating;

                if (stat.Value > 100.0f) stat.Value = 100.0f;
            }
        }

        private static StatsGroup GetStatGroup(string stat)
        {
            switch (stat)
            {
                case PlayerStatsWrapper.ACCELERATION:
                case PlayerStatsWrapper.SPRINT_SPEED:
                    return StatsGroup.Speed;
                case PlayerStatsWrapper.SHOTS:
                case PlayerStatsWrapper.LONG_SHOTS:
                case PlayerStatsWrapper.FREE_CICKS:
                case PlayerStatsWrapper.PENALTIES:
                    return StatsGroup.Shooting;
                case PlayerStatsWrapper.SHORT_PASSING:
                case PlayerStatsWrapper.LONG_PASSING:
                case PlayerStatsWrapper.CROSSING:
                    return StatsGroup.Passing;
                case PlayerStatsWrapper.BALL_CONTROL:
                case PlayerStatsWrapper.AGILITY:
                case PlayerStatsWrapper.TRICKS:
                    return StatsGroup.Technique;
                case PlayerStatsWrapper.INTERCEPTIONS:
                case PlayerStatsWrapper.STANDING_TACKLES:
                case PlayerStatsWrapper.SLIDING_TACKLES:
                    return StatsGroup.Defending;
                case PlayerStatsWrapper.JUMPING:
                case PlayerStatsWrapper.STRENGTH:
                case PlayerStatsWrapper.HEADING:
                case PlayerStatsWrapper.STAMINA:
                    return StatsGroup.Physical;
                case PlayerStatsWrapper.HAND_PLAY:
                case PlayerStatsWrapper.KICKING:
                case PlayerStatsWrapper.REFLEXES:
                case PlayerStatsWrapper.POSITIONING:
                    return StatsGroup.Goalkeeping;
            }

            throw new Exception("Can't find stat group");
        }

        private static int GetPlayerLevel(int level)
        {
            var item = PlayerLevelMapper.Items.First(i => i.Level == level);

            var rnd = new Random();

            return rnd.Next(item.MinOverallRating, item.MaxOverallRating);
        }
    }
}
