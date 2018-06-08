using Backend.Models.BuildingModels;

namespace Backend.Builders.Buildings
{
    public class AcademyBuilder
    {
        public static Academy GetAcademy()
        {
            return new Academy()
            {
                Level = 1
            };
        }
    }
}
