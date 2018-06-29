using System.Collections.Generic;
using DomainModels.Interfaces;
using DomainModels.Models.PlayerEntities;

namespace DomainModels.Models.ClubEntities
{
    public class HollOfFame : IDatabaseEntity
    {
        public long Id { get; set; }

        public List<Legend> Legends { get; set; }

        public Club Club { get; set; }
    }
}
