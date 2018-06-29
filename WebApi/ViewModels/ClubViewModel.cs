using System;
using System.Collections.Generic;
using DomainModels.Enums;
using DomainModels.Models;
using DomainModels.Models.ClubEntities;

namespace WebApi.ViewModels
{
    public class ClubViewModel
    {
        public string Name { get; set; }

        public Country Country { get; set; }

        public DateTime FoundationDate { get; set; }

        public List<PlayerViewModel> Players { get; set; }

        public static ClubViewModel Get(Club club)
        {
            var players = new List<PlayerViewModel>();
            foreach (var p in club.Players)
            {
                players.Add(PlayerViewModel.Get(p));
            }

            return new ClubViewModel
            {
                Name = club.Name,
                Country = club.Country,
                FoundationDate = club.FoundationDate,
                Players = players
            };
        }
    }
}
