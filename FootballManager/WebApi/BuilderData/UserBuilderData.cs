using BusinessLayer.Builders.BuildersData;
using DomainModels.Enums;

namespace WebApi.BuilderData
{
    public class UserBuilderData : IUserBuilderData
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Country Country { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }
    }
}
