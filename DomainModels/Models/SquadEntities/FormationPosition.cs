using DomainModels.Enums;

namespace DomainModels.Models.SquadEntities
{
    public class FormationPosition
    {
        public int Id { get; set; }

        public PlayerPosition PlayerPosition { get; set; }

        public FormationPositionType FormationPositionType { get; set; }

        public long? PlayerId { get; set; }

        public long SquadId { get; set; }

        public Squad Squad { get; set; }
    }
}
