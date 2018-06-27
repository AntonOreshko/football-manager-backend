using DomainModels.Models.SquadEntities;

namespace WebApi.ViewModels
{
    public class FormationPositionViewModel
    {
        public string PlayerPosition { get; set; }

        public string FormationPositionType { get; set; }

        public long? PlayerId { get; set; }

        public static FormationPositionViewModel Get(FormationPosition formationPosition)
        {
            return new FormationPositionViewModel
            {
                PlayerPosition = formationPosition.PlayerPosition.ToString(),
                FormationPositionType = formationPosition.FormationPositionType.ToString(),
                PlayerId = formationPosition.PlayerId
            };
        }
    }
}
