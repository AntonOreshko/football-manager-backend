using DomainModels.Enums;
using DomainModels.Interfaces;

namespace DomainModels.Models.EmployeeEntities
{
    public class Employee : IDatabaseEntity, IPerson, IUpgradable
    {
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Country Country { get; set; }

        public int Level { get; set; }

        public long ClubId { get; set; }

        public Club Club { get; set; }
    }
}
