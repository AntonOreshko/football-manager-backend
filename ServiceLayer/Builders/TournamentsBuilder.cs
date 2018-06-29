using BusinessLayer.ServiceInterfaces;

namespace BusinessLayer.Builders
{
    public static class TournamentsBuilder
    {
        private static IClubService ClubService { get; set; }

        private static IPlayerService PlayerService { get; set; }

        static TournamentsBuilder()
        {

        }
    }
}
