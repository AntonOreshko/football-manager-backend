using BusinessLayer.Builders.BuildersData;
using BusinessLayer.Configs;
using BusinessLayer.Mappers;
using DomainModels.Models.PlayerEntities;

namespace BusinessLayer.Builders
{
    public static class PlayerBuilder
    {
        private static readonly IConfigItem<AgeMapper> AgeMapperConfig;

        private static readonly IConfigItem<ConstitutionMapper> ConstitutionMapperConfig;

        private static readonly IConfigItem<PlayerLevelMapper> PlayerLevelConfig;

        private static readonly IConfigItem<PlayerPositionMapper> PlayerPositionConfig;

        private static readonly IConfigItem<StatsGroupMapper> StatsGroupConfig;

        private static readonly IConfigItem<TalentMapper> TalentConfig;

        static PlayerBuilder()
        {
            AgeMapperConfig = ConfigBuilder.GetConfig<AgeMapper>();
            ConstitutionMapperConfig = ConfigBuilder.GetConfig<ConstitutionMapper>();
            PlayerLevelConfig = ConfigBuilder.GetConfig<PlayerLevelMapper>();
            PlayerPositionConfig = ConfigBuilder.GetConfig<PlayerPositionMapper>();
            StatsGroupConfig = ConfigBuilder.GetConfig<StatsGroupMapper>();
            TalentConfig = ConfigBuilder.GetConfig<TalentMapper>();
        }

        public static Player Get(IPlayerBuilderData playerBuilderData)
        {
            return new Player();
        }
    }
}
