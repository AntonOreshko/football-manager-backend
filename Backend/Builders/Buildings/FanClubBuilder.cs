using Backend.Models.BuildingModels;

namespace Backend.Builders.Buildings
{
    public class FanClubBuilder
    {
        public static FanClub GetFanClub()
        {
            return new FanClub()
            {
                Level = 1
            };
        }
    }
}
