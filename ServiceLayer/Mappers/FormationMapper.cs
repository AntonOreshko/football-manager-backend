using System.Collections.Generic;
using DomainModels.Enums;

namespace BusinessLayer.Mappers
{
    public class FormationMapper
    {
        public List<FormationItem> Items { get; set; }
    }

    public class FormationItem
    {
        public Formation Formation { get; set; }

        public List<PlayerPosition> Positions { get; set; }
    }
}
