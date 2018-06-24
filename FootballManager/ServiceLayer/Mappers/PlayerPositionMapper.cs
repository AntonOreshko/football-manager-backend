using System.Collections.Generic;
using DomainModels.Enums;

namespace BusinessLayer.Mappers
{
    public class PlayerPositionMapper
    {
        public List<PlayerPositionItem> Items { get; set; }
    }

    public class PlayerPositionItem
    {
        public int StatsGenerationDelta = 10;

        public PlayerPosition PlayerPosition { get; set; }

        public Dictionary<HeightType, int> HeighTypePercents { get; set; }

        public Dictionary<BodyType, int> BodyTypePercents { get; set; }

        public Dictionary<StatsGroup, float> StatsGenerationMedianas { get; set; }

        public Dictionary<string, float> StatsOverallCoefficients { get; set; }
    }
}
