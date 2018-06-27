using DomainModels.Enums;

namespace BusinessLayer.Builders.BuildersData
{
    public interface IClubBuilderData
    {
        string Name { get; set; }

        Country Country { get; set; }
    }
}
