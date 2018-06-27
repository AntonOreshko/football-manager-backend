using System;
using System.Collections.Generic;
using System.Text;
using DomainModels.Enums;

namespace DomainModels.Interfaces
{
    public interface IPerson
    {
        string FirstName { get; set; }

        string LastName { get; set; }

        Country Country { get; set; }
    }
}
