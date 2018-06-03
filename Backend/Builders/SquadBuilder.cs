using Backend.Enums;
using Backend.Helpers;
using Backend.Models;
using Backend.Models.PlayerModels;
using Backend.Models.SquadModels;
using System.Collections.Generic;

namespace Backend.Builders
{
    public class SquadBuilder
    {
        public static Squad GetSquad(Club club, Formation formation)
        {
            var squad = new Squad();

            squad.Club = club;
            squad.IsActive = true;

            squad.FormationData = FormationBuilder.GetFormationData(squad, formation);

            return squad;
        }

        public static void AddStartPlayersToSquad(Club club, FormationData formationData)
        {
            RandomShuffleListCreator<FormationPosition> shuffledPositions = new RandomShuffleListCreator<FormationPosition>(formationData.FormationPositions);

            RandomShuffleListCreator<int> shuffledLevels = new RandomShuffleListCreator<int>(new List<int>
            {
                1, 1, 1, 1, 1, 1, 1, 1,
                2, 2, 2, 2, 2, 2,
                3, 3, 3, 3
            });

            club.Players = new List<Player>();

            for (int i = 0; i < formationData.FormationPositions.Count; i++)
            {
                var formationPosition = shuffledPositions.Get();
                var level = shuffledLevels.Get();

                club.Players.Add(PlayerBuilder.CreatePlayer(club, formationPosition, level));
            }
        }
    }
}
