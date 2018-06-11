using DomainModels.Enums;

namespace BusinessLayer.Builders.BuildersData
{
    public interface IUserBuilderData
    {
        string FirstName { get; set; }

        string LastName { get; set; }

        Country Country { get; set; }

        string Login { get; set; }

        string Password { get; set; }
    }
}
