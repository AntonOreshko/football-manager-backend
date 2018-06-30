using System.Collections.Generic;
using System.Linq;
using BusinessLayer.Data;
using BusinessLayer.ServiceInterfaces;
using DomainModels.Enums;
using DomainModels.Models.ClubEntities;
using DomainModels.Models.TournamentEntities;

namespace BusinessLayer.Builders
{
    public static class TournamentsBuilder
    {
        private static List<DrawBasket> GetDrawBasketsForLeague(int level, IClubService clubService)
        {
            var clubs = clubService.GetByLevel(level).ToList();

            var averageRatings = clubs.Select(p => new KeyValuePair<long, float>(p.Id, clubService.GetAverageSquadRating(p.Id))).ToList();

            averageRatings = new List<KeyValuePair<long, float>>(averageRatings.OrderByDescending(ar => ar.Value));

            int basket1Size = clubs.Count / 10 * 3;
            int basket2Size = clubs.Count / 10 * 3;
            int basket3Size = clubs.Count / 10 * 4;

            int[] potSizes = { basket1Size, basket2Size, basket3Size };

            var basketsForLeague = new List<DrawBasket>();
            foreach (var ps in potSizes)
            {
                var ratings = averageRatings.GetRange(0, ps).ToList();
                var keys = ratings.Select(ar => ar.Key).ToList();
                var potClubs = clubs.Where(p => keys.Contains(p.Id)).ToList();

                clubs.RemoveAll(p => keys.Contains(p.Id));
                averageRatings.RemoveAll(ar => ratings.Contains(ar));

                basketsForLeague.Add(new DrawBasket()
                {
                    Clubs = potClubs.ToList()
                });
            }

            return basketsForLeague;
        }

        public static List<Tournament> GetLeagues(int level, IClubService clubService)
        {
            int tournamentsCount = clubService.GetClubsCountByLevel(level) / 10;
            var baskets = GetDrawBasketsForLeague(level, clubService);
            var tournaments = new List<Tournament>();

            for (int i = 0; i < tournamentsCount; i++)
            {
                var tournament = new Tournament
                {
                    Level = level,
                    CurrentStage = 0,
                    IsFinished = false,
                    TournamentType = TournamentType.League,
                    TournamentClubs = new List<TournamentClub>()
                };

                var clubs = new List<Club>();
                for (int j = 0; j < 3; j++)
                {
                    clubs.Add(baskets[0].GetRandomClub());
                }
                for (int j = 0; j < 3; j++)
                {
                    clubs.Add(baskets[1].GetRandomClub());
                }
                for (int j = 0; j < 4; j++)
                {
                    clubs.Add(baskets[2].GetRandomClub());
                }

                foreach (var c in clubs)
                {
                    tournament.TournamentClubs.Add(new TournamentClub
                    {
                        Tournament = tournament,
                        Club = c
                    });
                }
                
                tournaments.Add(tournament);
            }

            return tournaments;
        }
    }
}
