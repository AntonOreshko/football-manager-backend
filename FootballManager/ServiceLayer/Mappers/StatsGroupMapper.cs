using System.Collections.Generic;
using BusinessLayer.Wrappers;
using DomainModels.Enums;

namespace BusinessLayer.Mappers
{
    public class StatsGroupMapper
    {
        public List<StatsGroupItem> Items { get; set; }
    }

    public class StatsGroupItem
    {
        public StatsGroup StatsGroup { get; set; }

        public Dictionary<string, float> StatsGroupCoefficients { get; set; }

        public float GetStatsGroupRating(PlayerStatsWrapper stats)
        {
            var rating = 0.0f;
            foreach (var s in StatsGroupCoefficients)
            {
                rating += s.Value * stats.GetValue(s.Key);
            }
            return rating;
        }
    }
}
