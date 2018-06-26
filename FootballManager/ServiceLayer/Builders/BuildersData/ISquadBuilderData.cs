using DomainModels.Enums;

namespace BusinessLayer.Builders.BuildersData
{
    public interface ISquadBuilderData
    {
        bool IsActive { get; set; }

        Formation Formation { get; set; }

    }
}
