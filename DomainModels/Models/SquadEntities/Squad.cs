using System.Collections.Generic;
using DomainModels.Enums;
using DomainModels.Interfaces;
using DomainModels.Models.ClubEntities;

namespace DomainModels.Models.SquadEntities
{
    public class Squad : IDatabaseEntity
    {
        public long Id { get; set; }

        public bool IsActive { get; set; }

        public Formation Formation { get; set; }

        public long ClubId { get; set; }

        public Club Club { get; set; }

        public List<FormationPosition> FormationPositions { get; set; }
    }
}
