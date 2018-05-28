using Backend.Enums;
using Backend.Models;
using Backend.Models.SquadModels;

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
    }
}
