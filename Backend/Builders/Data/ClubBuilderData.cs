using Backend.Enums;

namespace Backend.Builders.Data
{
    public class ClubBuilderData
    {
        public string Name { get; set; }

        public Country Country { get; set; }

        public Formation Formation { get; set; }

        public static ClubBuilderData GetRandom(UserBuilderData userBuilderData)
        {
            var builderData = new ClubBuilderData
            {
                Name = userBuilderData.FirstName + "'s Club",
                Country = userBuilderData.UserCountry,
                Formation = FormationBuilder.GetRandomFormation()
            };
            return builderData;
        }
    }
}
