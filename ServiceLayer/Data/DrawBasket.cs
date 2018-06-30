using System;
using System.Collections.Generic;
using DomainModels.Models.ClubEntities;

namespace BusinessLayer.Data
{
    public class DrawBasket
    {
        public List<Club> Clubs { get; set; }

        private Random _rnd = new Random();

        public Club GetRandomClub()
        {
            if (Clubs.Count > 0)
            {
                var club = Clubs[_rnd.Next(Clubs.Count - 1)];
                Clubs.Remove(club);

                return club;
            }

            var club1 = Clubs[0];
            Clubs.Remove(club1);

            return club1;

        }
    }
}
