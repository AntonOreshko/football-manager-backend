using System.Collections.Generic;
using System.Linq;
using DomainModels.Models.TournamentEntities;

namespace WebApi.ViewModels
{
    public class TournamentViewModel
    {
        public int Level { get; set; }

        public int CurrentStage { get; set; }

        public bool IsFinished { get; set; }

        public string TournamentType { get; set; }

        public List<ClubViewModel> Clubs { get; set; }

        public static TournamentViewModel Get(Tournament tournament)
        {
            var clubViewModels = tournament.TournamentClubs.Select(tc => tc.Club).Select(ClubViewModel.Get).ToList();

            return new TournamentViewModel
            {
                Level = tournament.Level,
                CurrentStage = tournament.CurrentStage,
                IsFinished = tournament.IsFinished,
                TournamentType = tournament.TournamentType.ToString(),
                Clubs = clubViewModels
            };
        }
    }
}
