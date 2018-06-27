using System;
using System.Collections.Generic;
using DomainModels.Enums;
using DomainModels.Interfaces;
using DomainModels.Models.BuildingEntities;
using DomainModels.Models.EmployeeEntities;
using DomainModels.Models.PlayerEntities;
using DomainModels.Models.SquadEntities;
using DomainModels.Models.TournamentEntities;

namespace DomainModels.Models
{
    public class Club : IDatabaseEntity
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public Country Country { get; set; }

        public DateTime FoundationDate { get; set; }

        public long UserId { get; set; }

        public User User { get; set; }

        public List<Player> Players { get; set; }

        public List<Building> Buildings { get; set; }

        public List<Employee> Employees { get; set; }

        public List<Squad> Squads { get; set; }

        public List<TournamentClub> TournamentClubs { get; set; }
    }
}
