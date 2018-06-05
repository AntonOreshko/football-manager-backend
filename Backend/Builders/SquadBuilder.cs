using Backend.Enums;
using Backend.Helpers;
using Backend.Models.PlayerModels;
using Backend.Models.SquadModels;
using System.Collections.Generic;
using Backend.Builders.Data;

namespace Backend.Builders
{
    public class SquadBuilder
    {
        public static Squad GetSquad(SquadBuilderData squadBuilderData)
        {
            var squad = new Squad();

            squad.IsActive = squadBuilderData.IsActive;
            squad.Formation = squadBuilderData.Formation;



            return squad;
        }

        public static void AddStartPlayersToSquad(Squad squad, Formation formation)
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
