using System.Collections.Generic;
using DomainModels.Interfaces;

namespace DomainModels.Models.ClubEntities
{
    public class ClubHistory : IDatabaseEntity
    {
        public long Id { get; set; }

        public Club Club { get; set; }

        public List<SeasonResult> SeasonResults { get; set; }
    }
}
