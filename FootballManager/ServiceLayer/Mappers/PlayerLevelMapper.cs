using System.Collections.Generic;

namespace BusinessLayer.Mappers
{
    public class PlayerLevelMapper
    {
        public List<PlayerLevelItem> Items { get; set; }
    }

    public class PlayerLevelItem
    {
        public int Level { get; set; }

        public int MinOverallRating { get; set; }

        public int MaxOverallRating { get; set; }
    }
}
