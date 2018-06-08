using Backend.Models.BuildingModels;

namespace Backend.Builders.Buildings
{
    public class StadiumBuilder
    {
        public static Stadium GetStadium()
        {
            return new Stadium()
            {
                Level = 1
            };
        }
    }
}
