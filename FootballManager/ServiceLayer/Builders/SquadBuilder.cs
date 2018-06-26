using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLayer.Builders.BuildersData;
using BusinessLayer.Mappers;
using DomainModels.Enums;
using DomainModels.Models.SquadEntities;

namespace BusinessLayer.Builders
{
    public static class SquadBuilder
    {
        private static readonly FormationMapper FormationMapper;

        static SquadBuilder()
        {
            FormationMapper = ConfigBuilder.GetConfig<FormationMapper>().Get();
        }

        public static Squad GetSquad(ISquadBuilderData squadBuilderData)
        {
            var squad = new Squad
            {
                IsActive = squadBuilderData.IsActive,
                Formation = squadBuilderData.Formation,
                FormationPositions = GetFormationPositions(squadBuilderData.Formation)
            };

            return squad;
        }

        public static Squad GetRandomSquad()
        {
            var formation = GetRandomFormation();

            var squad = new Squad
            {
                IsActive = true,
                Formation = formation,
                FormationPositions = GetFormationPositions(formation)
            };

            return squad;
        }


        private static Formation GetRandomFormation()
        {
            var values = Enum.GetValues(typeof(Formation));
            var random = new Random();
            var formation = (Formation)values.GetValue(random.Next(values.Length));

            return formation;
        }

        private static List<FormationPosition> GetFormationPositions(Formation formation)
        {
            var positions = FormationMapper.Items.First(i => i.Formation == formation).Positions;

            var formationPositions = new List<FormationPosition>();
            for (var i = 0; i < positions.Count; i++)
            {
                var fposition = new FormationPosition
                {
                    PlayerPosition = positions[i]
                };
                fposition.FormationPositionType = i < 11
                    ? fposition.FormationPositionType = FormationPositionType.Start
                    : fposition.FormationPositionType = FormationPositionType.Bench;

                formationPositions.Add(fposition);
            }

            return formationPositions;
        }
    }
}
