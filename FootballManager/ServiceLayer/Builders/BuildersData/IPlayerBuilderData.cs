using DomainModels.Enums;

namespace BusinessLayer.Builders.BuildersData
{
    public interface IPlayerBuilderData
    {
        Country Country { get; set; }

        PlayerPosition Position { get; set; }

        int Level { get; set; }
    }
}
