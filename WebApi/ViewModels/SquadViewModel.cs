using System.Collections.Generic;
using DomainModels.Models.SquadEntities;

namespace WebApi.ViewModels
{
    public class SquadViewModel
    {
        public string Formation { get; set; }

        public List<FormationPositionViewModel> FormationPositions { get; set; }

        public static SquadViewModel Get(Squad squad)
        {
            var formationPositions = new List<FormationPositionViewModel>();
            foreach (var pos in squad.FormationPositions)
            {
                formationPositions.Add(FormationPositionViewModel.Get(pos));
            }

            return new SquadViewModel
            {
                Formation = squad.Formation.ToString(),
                FormationPositions = formationPositions
            };
        }
    }
}
