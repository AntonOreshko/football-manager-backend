using BusinessLayer.Builders.BuildersData;
using DomainModels.Enums;

namespace WebApi.BuilderData
{
    public class ClubBuilderData : IClubBuilderData
    {
        public string Name { get; set; }

        public Country Country { get; set; }
    }
}
