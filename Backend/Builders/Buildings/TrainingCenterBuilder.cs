using Backend.Models.BuildingModels;

namespace Backend.Builders.Buildings
{
    public class TrainingCenterBuilder
    {
        public static TrainingCenter GetTrainingCenter()
        {
            return new TrainingCenter()
            {
                Level = 1
            };
        }
    }
}
