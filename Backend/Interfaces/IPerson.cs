using Backend.Enums;

namespace Backend.Interfaces
{
    public interface IPerson
    {
        string FirstName { get; set; }

        string LastName { get; set; }

        Country Country { get; set; }
    }
}
