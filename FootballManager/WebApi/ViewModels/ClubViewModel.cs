using System;
using DomainModels.Enums;

namespace WebApi.ViewModels
{
    public class ClubViewModel
    {
        public string Name { get; set; }

        public Country Country { get; set; }

        public DateTime FoundationDate { get; set; }

        public static ClubViewModel Get(ClubViewModel club)
        {
            return new ClubViewModel
            {
                Name = club.Name,
                Country = club.Country,
                FoundationDate = club.FoundationDate
            };
        }
    }
}
