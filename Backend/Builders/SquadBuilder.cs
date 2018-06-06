using System;
using Backend.Enums;
using Backend.Models.SquadModels;
using System.Collections.Generic;
using Backend.Builders.Data;

namespace Backend.Builders
{
    public class SquadBuilder
    {
        public static Squad GetSquad(SquadBuilderData squadBuilderData)
        {
            var squad = new Squad
            {
                IsActive = squadBuilderData.IsActive,
                Formation = squadBuilderData.Formation,
                FormationPositions = GetFormationPositions(squadBuilderData.Formation)
            };
            return squad;
        }

        public static List<FormationPosition> GetFormationPositions(Formation formation)
        {
            List<FormationPosition> positions = null;

            switch (formation)
            {
                case Formation.Formation_3_4_1_2:
                    positions = GetFormationPositions_3_4_1_2();
                    break;
                case Formation.Formation_3_4_3:
                    positions = GetFormationPositions_3_4_3();
                    break;
                case Formation.Formation_3_5_2:
                    positions = GetFormationPositions_3_5_2();
                    break;
                case Formation.Formation_4_1_2_1_2_A:
                    positions = GetFormationPositions_4_1_2_1_2_A();
                    break;
                case Formation.Formation_4_1_2_1_2_B:
                    positions = GetFormationPositions_4_1_2_1_2_B();
                    break;
                case Formation.Formation_4_2_3_1_A:
                    positions = GetFormationPositions_4_2_3_1_A();
                    break;
                case Formation.Formation_4_2_3_1_B:
                    positions = GetFormationPositions_4_2_3_1_B();
                    break;
                case Formation.Formation_4_2_2_2:
                    positions = GetFormationPositions_4_2_2_2();
                    break;
                case Formation.Formation_4_3_1_2:
                    positions = GetFormationPositions_4_3_1_2();
                    break;
                case Formation.Formation_4_3_3_A:
                    positions = GetFormationPositions_4_3_3_A();
                    break;
                case Formation.Formation_4_3_3_B:
                    positions = GetFormationPositions_4_3_3_B();
                    break;
                case Formation.Formation_4_3_3_C:
                    positions = GetFormationPositions_4_3_3_C();
                    break;
                case Formation.Formation_4_3_3_D:
                    positions = GetFormationPositions_4_3_3_D();
                    break;
                case Formation.Formation_4_4_2_A:
                    positions = GetFormationPositions_4_4_2_A();
                    break;
                case Formation.Formation_4_4_2_B:
                    positions = GetFormationPositions_4_4_2_B();
                    break;
                case Formation.Formation_5_2_1_2:
                    positions = GetFormationPositions_5_2_1_2();
                    break;
                case Formation.Formation_5_2_2_1:
                    positions = GetFormationPositions_5_2_2_1();
                    break;
                case Formation.Formation_5_3_2:
                    positions = GetFormationPositions_5_3_2();
                    break;
            }

            AddFormationPositionsCommonData(positions);

            return positions;
        }

        #region Formations Filling

        public static List<FormationPosition> GetFormationPositions_3_4_1_2()
        {
            var positions = new List<FormationPosition>()
            {
                new FormationPosition { PlayerPosition = PlayerPosition.GK },
                new FormationPosition { PlayerPosition = PlayerPosition.CB },
                new FormationPosition { PlayerPosition = PlayerPosition.CB },
                new FormationPosition { PlayerPosition = PlayerPosition.CB },
                new FormationPosition { PlayerPosition = PlayerPosition.LM },
                new FormationPosition { PlayerPosition = PlayerPosition.CM },
                new FormationPosition { PlayerPosition = PlayerPosition.CM },
                new FormationPosition { PlayerPosition = PlayerPosition.RM },
                new FormationPosition { PlayerPosition = PlayerPosition.CAM },
                new FormationPosition { PlayerPosition = PlayerPosition.ST },
                new FormationPosition { PlayerPosition = PlayerPosition.ST },

                new FormationPosition { PlayerPosition = PlayerPosition.GK },
                new FormationPosition { PlayerPosition = PlayerPosition.CB },
                new FormationPosition { PlayerPosition = PlayerPosition.CM },
                new FormationPosition { PlayerPosition = PlayerPosition.CAM },
                new FormationPosition { PlayerPosition = PlayerPosition.LM },
                new FormationPosition { PlayerPosition = PlayerPosition.RM },
                new FormationPosition { PlayerPosition = PlayerPosition.ST },
            };

            return positions;
        }

        public static List<FormationPosition> GetFormationPositions_3_4_3()
        {
            var positions = new List<FormationPosition>()
            {
                new FormationPosition { PlayerPosition = PlayerPosition.GK },
                new FormationPosition { PlayerPosition = PlayerPosition.CB },
                new FormationPosition { PlayerPosition = PlayerPosition.CB },
                new FormationPosition { PlayerPosition = PlayerPosition.CB },
                new FormationPosition { PlayerPosition = PlayerPosition.LM },
                new FormationPosition { PlayerPosition = PlayerPosition.CM },
                new FormationPosition { PlayerPosition = PlayerPosition.CM },
                new FormationPosition { PlayerPosition = PlayerPosition.RM },
                new FormationPosition { PlayerPosition = PlayerPosition.LF },
                new FormationPosition { PlayerPosition = PlayerPosition.ST },
                new FormationPosition { PlayerPosition = PlayerPosition.RF },

                new FormationPosition { PlayerPosition = PlayerPosition.GK },
                new FormationPosition { PlayerPosition = PlayerPosition.CB },
                new FormationPosition { PlayerPosition = PlayerPosition.CM },
                new FormationPosition { PlayerPosition = PlayerPosition.CM },
                new FormationPosition { PlayerPosition = PlayerPosition.LM },
                new FormationPosition { PlayerPosition = PlayerPosition.RM },
                new FormationPosition { PlayerPosition = PlayerPosition.ST },
            };

            return positions;
        }

        public static List<FormationPosition> GetFormationPositions_3_5_2()
        {
            var positions = new List<FormationPosition>()
            {
                new FormationPosition { PlayerPosition = PlayerPosition.GK },
                new FormationPosition { PlayerPosition = PlayerPosition.CB },
                new FormationPosition { PlayerPosition = PlayerPosition.CB },
                new FormationPosition { PlayerPosition = PlayerPosition.CB },
                new FormationPosition { PlayerPosition = PlayerPosition.LM },
                new FormationPosition { PlayerPosition = PlayerPosition.CDM },
                new FormationPosition { PlayerPosition = PlayerPosition.CDM },
                new FormationPosition { PlayerPosition = PlayerPosition.RM },
                new FormationPosition { PlayerPosition = PlayerPosition.CAM },
                new FormationPosition { PlayerPosition = PlayerPosition.ST },
                new FormationPosition { PlayerPosition = PlayerPosition.ST },

                new FormationPosition { PlayerPosition = PlayerPosition.GK },
                new FormationPosition { PlayerPosition = PlayerPosition.CB },
                new FormationPosition { PlayerPosition = PlayerPosition.CDM },
                new FormationPosition { PlayerPosition = PlayerPosition.LM },
                new FormationPosition { PlayerPosition = PlayerPosition.RM },
                new FormationPosition { PlayerPosition = PlayerPosition.CAM },
                new FormationPosition { PlayerPosition = PlayerPosition.ST },
            };

            return positions;
        }

        public static List<FormationPosition> GetFormationPositions_4_1_2_1_2_A()
        {
            var positions = new List<FormationPosition>()
            {
                new FormationPosition { PlayerPosition = PlayerPosition.GK },
                new FormationPosition { PlayerPosition = PlayerPosition.LB },
                new FormationPosition { PlayerPosition = PlayerPosition.CB },
                new FormationPosition { PlayerPosition = PlayerPosition.CB },
                new FormationPosition { PlayerPosition = PlayerPosition.RB },
                new FormationPosition { PlayerPosition = PlayerPosition.CDM },
                new FormationPosition { PlayerPosition = PlayerPosition.LM },
                new FormationPosition { PlayerPosition = PlayerPosition.RM },
                new FormationPosition { PlayerPosition = PlayerPosition.CAM },
                new FormationPosition { PlayerPosition = PlayerPosition.ST },
                new FormationPosition { PlayerPosition = PlayerPosition.ST },

                new FormationPosition { PlayerPosition = PlayerPosition.GK },
                new FormationPosition { PlayerPosition = PlayerPosition.CB },
                new FormationPosition { PlayerPosition = PlayerPosition.CDM },
                new FormationPosition { PlayerPosition = PlayerPosition.LM },
                new FormationPosition { PlayerPosition = PlayerPosition.RM },
                new FormationPosition { PlayerPosition = PlayerPosition.CAM },
                new FormationPosition { PlayerPosition = PlayerPosition.ST },
            };

            return positions;
        }

        public static List<FormationPosition> GetFormationPositions_4_1_2_1_2_B()
        {
            var positions = new List<FormationPosition>()
            {
                new FormationPosition { PlayerPosition = PlayerPosition.GK },
                new FormationPosition { PlayerPosition = PlayerPosition.LB },
                new FormationPosition { PlayerPosition = PlayerPosition.CB },
                new FormationPosition { PlayerPosition = PlayerPosition.CB },
                new FormationPosition { PlayerPosition = PlayerPosition.RB },
                new FormationPosition { PlayerPosition = PlayerPosition.CDM },
                new FormationPosition { PlayerPosition = PlayerPosition.CM },
                new FormationPosition { PlayerPosition = PlayerPosition.CM },
                new FormationPosition { PlayerPosition = PlayerPosition.CAM },
                new FormationPosition { PlayerPosition = PlayerPosition.ST },
                new FormationPosition { PlayerPosition = PlayerPosition.ST },

                new FormationPosition { PlayerPosition = PlayerPosition.GK },
                new FormationPosition { PlayerPosition = PlayerPosition.CB },
                new FormationPosition { PlayerPosition = PlayerPosition.CDM },
                new FormationPosition { PlayerPosition = PlayerPosition.CM },
                new FormationPosition { PlayerPosition = PlayerPosition.CM },
                new FormationPosition { PlayerPosition = PlayerPosition.CAM },
                new FormationPosition { PlayerPosition = PlayerPosition.ST },
            };

            return positions;
        }

        public static List<FormationPosition> GetFormationPositions_4_2_3_1_A()
        {
            var positions = new List<FormationPosition>()
            {
                new FormationPosition { PlayerPosition = PlayerPosition.GK },
                new FormationPosition { PlayerPosition = PlayerPosition.LB },
                new FormationPosition { PlayerPosition = PlayerPosition.CB },
                new FormationPosition { PlayerPosition = PlayerPosition.CB },
                new FormationPosition { PlayerPosition = PlayerPosition.RB },
                new FormationPosition { PlayerPosition = PlayerPosition.CDM },
                new FormationPosition { PlayerPosition = PlayerPosition.CDM },
                new FormationPosition { PlayerPosition = PlayerPosition.CAM },
                new FormationPosition { PlayerPosition = PlayerPosition.CAM },
                new FormationPosition { PlayerPosition = PlayerPosition.CAM },
                new FormationPosition { PlayerPosition = PlayerPosition.ST },

                new FormationPosition { PlayerPosition = PlayerPosition.GK },
                new FormationPosition { PlayerPosition = PlayerPosition.CB },
                new FormationPosition { PlayerPosition = PlayerPosition.CDM },
                new FormationPosition { PlayerPosition = PlayerPosition.CDM },
                new FormationPosition { PlayerPosition = PlayerPosition.CAM },
                new FormationPosition { PlayerPosition = PlayerPosition.CAM },
                new FormationPosition { PlayerPosition = PlayerPosition.ST },
            };

            return positions;
        }

        public static List<FormationPosition> GetFormationPositions_4_2_3_1_B()
        {
            var positions = new List<FormationPosition>()
            {
                new FormationPosition { PlayerPosition = PlayerPosition.GK },
                new FormationPosition { PlayerPosition = PlayerPosition.LB },
                new FormationPosition { PlayerPosition = PlayerPosition.CB },
                new FormationPosition { PlayerPosition = PlayerPosition.CB },
                new FormationPosition { PlayerPosition = PlayerPosition.RB },
                new FormationPosition { PlayerPosition = PlayerPosition.CDM },
                new FormationPosition { PlayerPosition = PlayerPosition.CDM },
                new FormationPosition { PlayerPosition = PlayerPosition.LM },
                new FormationPosition { PlayerPosition = PlayerPosition.CAM },
                new FormationPosition { PlayerPosition = PlayerPosition.RM },
                new FormationPosition { PlayerPosition = PlayerPosition.ST },

                new FormationPosition { PlayerPosition = PlayerPosition.GK },
                new FormationPosition { PlayerPosition = PlayerPosition.CB },
                new FormationPosition { PlayerPosition = PlayerPosition.CDM },
                new FormationPosition { PlayerPosition = PlayerPosition.LM },
                new FormationPosition { PlayerPosition = PlayerPosition.CAM },
                new FormationPosition { PlayerPosition = PlayerPosition.RM },
                new FormationPosition { PlayerPosition = PlayerPosition.ST },
            };

            return positions;
        }

        public static List<FormationPosition> GetFormationPositions_4_2_2_2()
        {
            var positions = new List<FormationPosition>()
            {
                new FormationPosition { PlayerPosition = PlayerPosition.GK },
                new FormationPosition { PlayerPosition = PlayerPosition.LB },
                new FormationPosition { PlayerPosition = PlayerPosition.CB },
                new FormationPosition { PlayerPosition = PlayerPosition.CB },
                new FormationPosition { PlayerPosition = PlayerPosition.RB },
                new FormationPosition { PlayerPosition = PlayerPosition.CDM },
                new FormationPosition { PlayerPosition = PlayerPosition.CDM },
                new FormationPosition { PlayerPosition = PlayerPosition.CAM },
                new FormationPosition { PlayerPosition = PlayerPosition.CAM },
                new FormationPosition { PlayerPosition = PlayerPosition.ST },
                new FormationPosition { PlayerPosition = PlayerPosition.ST },

                new FormationPosition { PlayerPosition = PlayerPosition.GK },
                new FormationPosition { PlayerPosition = PlayerPosition.CB },
                new FormationPosition { PlayerPosition = PlayerPosition.CDM },
                new FormationPosition { PlayerPosition = PlayerPosition.CDM },
                new FormationPosition { PlayerPosition = PlayerPosition.CAM },
                new FormationPosition { PlayerPosition = PlayerPosition.CAM },
                new FormationPosition { PlayerPosition = PlayerPosition.ST },
            };

            return positions;
        }

        public static List<FormationPosition> GetFormationPositions_4_3_1_2()
        {
            var positions = new List<FormationPosition>()
            {
                new FormationPosition { PlayerPosition = PlayerPosition.GK },
                new FormationPosition { PlayerPosition = PlayerPosition.LB },
                new FormationPosition { PlayerPosition = PlayerPosition.CB },
                new FormationPosition { PlayerPosition = PlayerPosition.CB },
                new FormationPosition { PlayerPosition = PlayerPosition.RB },
                new FormationPosition { PlayerPosition = PlayerPosition.CM },
                new FormationPosition { PlayerPosition = PlayerPosition.CM },
                new FormationPosition { PlayerPosition = PlayerPosition.CM },
                new FormationPosition { PlayerPosition = PlayerPosition.CAM },
                new FormationPosition { PlayerPosition = PlayerPosition.ST },
                new FormationPosition { PlayerPosition = PlayerPosition.ST },

                new FormationPosition { PlayerPosition = PlayerPosition.GK },
                new FormationPosition { PlayerPosition = PlayerPosition.CB },
                new FormationPosition { PlayerPosition = PlayerPosition.CM },
                new FormationPosition { PlayerPosition = PlayerPosition.CM },
                new FormationPosition { PlayerPosition = PlayerPosition.CAM },
                new FormationPosition { PlayerPosition = PlayerPosition.ST },
                new FormationPosition { PlayerPosition = PlayerPosition.ST },
            };

            return positions;
        }

        public static List<FormationPosition> GetFormationPositions_4_3_3_A()
        {
            var positions = new List<FormationPosition>()
            {
                new FormationPosition { PlayerPosition = PlayerPosition.GK },
                new FormationPosition { PlayerPosition = PlayerPosition.LB },
                new FormationPosition { PlayerPosition = PlayerPosition.CB },
                new FormationPosition { PlayerPosition = PlayerPosition.CB },
                new FormationPosition { PlayerPosition = PlayerPosition.RB },
                new FormationPosition { PlayerPosition = PlayerPosition.CM },
                new FormationPosition { PlayerPosition = PlayerPosition.CM },
                new FormationPosition { PlayerPosition = PlayerPosition.CM },
                new FormationPosition { PlayerPosition = PlayerPosition.LF },
                new FormationPosition { PlayerPosition = PlayerPosition.ST },
                new FormationPosition { PlayerPosition = PlayerPosition.RF },

                new FormationPosition { PlayerPosition = PlayerPosition.GK },
                new FormationPosition { PlayerPosition = PlayerPosition.CB },
                new FormationPosition { PlayerPosition = PlayerPosition.CM },
                new FormationPosition { PlayerPosition = PlayerPosition.CM },
                new FormationPosition { PlayerPosition = PlayerPosition.LF },
                new FormationPosition { PlayerPosition = PlayerPosition.ST },
                new FormationPosition { PlayerPosition = PlayerPosition.RF },
            };

            return positions;
        }

        public static List<FormationPosition> GetFormationPositions_4_3_3_B()
        {
            var positions = new List<FormationPosition>()
            {
                new FormationPosition { PlayerPosition = PlayerPosition.GK },
                new FormationPosition { PlayerPosition = PlayerPosition.LB },
                new FormationPosition { PlayerPosition = PlayerPosition.CB },
                new FormationPosition { PlayerPosition = PlayerPosition.CB },
                new FormationPosition { PlayerPosition = PlayerPosition.RB },
                new FormationPosition { PlayerPosition = PlayerPosition.CDM },
                new FormationPosition { PlayerPosition = PlayerPosition.CM },
                new FormationPosition { PlayerPosition = PlayerPosition.CM },
                new FormationPosition { PlayerPosition = PlayerPosition.LF },
                new FormationPosition { PlayerPosition = PlayerPosition.ST },
                new FormationPosition { PlayerPosition = PlayerPosition.RF },

                new FormationPosition { PlayerPosition = PlayerPosition.GK },
                new FormationPosition { PlayerPosition = PlayerPosition.CB },
                new FormationPosition { PlayerPosition = PlayerPosition.CDM },
                new FormationPosition { PlayerPosition = PlayerPosition.CM },
                new FormationPosition { PlayerPosition = PlayerPosition.LF },
                new FormationPosition { PlayerPosition = PlayerPosition.ST },
                new FormationPosition { PlayerPosition = PlayerPosition.RF },
            };

            return positions;
        }

        public static List<FormationPosition> GetFormationPositions_4_3_3_C()
        {
            var positions = new List<FormationPosition>()
            {
                new FormationPosition { PlayerPosition = PlayerPosition.GK },
                new FormationPosition { PlayerPosition = PlayerPosition.LB },
                new FormationPosition { PlayerPosition = PlayerPosition.CB },
                new FormationPosition { PlayerPosition = PlayerPosition.CB },
                new FormationPosition { PlayerPosition = PlayerPosition.RB },
                new FormationPosition { PlayerPosition = PlayerPosition.CDM },
                new FormationPosition { PlayerPosition = PlayerPosition.CDM },
                new FormationPosition { PlayerPosition = PlayerPosition.CM },
                new FormationPosition { PlayerPosition = PlayerPosition.LF },
                new FormationPosition { PlayerPosition = PlayerPosition.ST },
                new FormationPosition { PlayerPosition = PlayerPosition.RF },

                new FormationPosition { PlayerPosition = PlayerPosition.GK },
                new FormationPosition { PlayerPosition = PlayerPosition.CB },
                new FormationPosition { PlayerPosition = PlayerPosition.CDM },
                new FormationPosition { PlayerPosition = PlayerPosition.CM },
                new FormationPosition { PlayerPosition = PlayerPosition.LF },
                new FormationPosition { PlayerPosition = PlayerPosition.ST },
                new FormationPosition { PlayerPosition = PlayerPosition.RF },
            };

            return positions;
        }

        public static List<FormationPosition> GetFormationPositions_4_3_3_D()
        {
            var positions = new List<FormationPosition>()
            {
                new FormationPosition { PlayerPosition = PlayerPosition.GK },
                new FormationPosition { PlayerPosition = PlayerPosition.LB },
                new FormationPosition { PlayerPosition = PlayerPosition.CB },
                new FormationPosition { PlayerPosition = PlayerPosition.CB },
                new FormationPosition { PlayerPosition = PlayerPosition.RB },
                new FormationPosition { PlayerPosition = PlayerPosition.CM },
                new FormationPosition { PlayerPosition = PlayerPosition.CM },
                new FormationPosition { PlayerPosition = PlayerPosition.CAM },
                new FormationPosition { PlayerPosition = PlayerPosition.LF },
                new FormationPosition { PlayerPosition = PlayerPosition.ST },
                new FormationPosition { PlayerPosition = PlayerPosition.RF },

                new FormationPosition { PlayerPosition = PlayerPosition.GK },
                new FormationPosition { PlayerPosition = PlayerPosition.CB },
                new FormationPosition { PlayerPosition = PlayerPosition.CM },
                new FormationPosition { PlayerPosition = PlayerPosition.CAM },
                new FormationPosition { PlayerPosition = PlayerPosition.LF },
                new FormationPosition { PlayerPosition = PlayerPosition.ST },
                new FormationPosition { PlayerPosition = PlayerPosition.RF },
            };

            return positions;
        }

        public static List<FormationPosition> GetFormationPositions_4_4_2_A()
        {
            var positions = new List<FormationPosition>()
            {
                new FormationPosition { PlayerPosition = PlayerPosition.GK },
                new FormationPosition { PlayerPosition = PlayerPosition.LB },
                new FormationPosition { PlayerPosition = PlayerPosition.CB },
                new FormationPosition { PlayerPosition = PlayerPosition.CB },
                new FormationPosition { PlayerPosition = PlayerPosition.RB },
                new FormationPosition { PlayerPosition = PlayerPosition.LM },
                new FormationPosition { PlayerPosition = PlayerPosition.CM },
                new FormationPosition { PlayerPosition = PlayerPosition.CM },
                new FormationPosition { PlayerPosition = PlayerPosition.RM },
                new FormationPosition { PlayerPosition = PlayerPosition.ST },
                new FormationPosition { PlayerPosition = PlayerPosition.ST },

                new FormationPosition { PlayerPosition = PlayerPosition.GK },
                new FormationPosition { PlayerPosition = PlayerPosition.CB },
                new FormationPosition { PlayerPosition = PlayerPosition.CM },
                new FormationPosition { PlayerPosition = PlayerPosition.CM },
                new FormationPosition { PlayerPosition = PlayerPosition.LM },
                new FormationPosition { PlayerPosition = PlayerPosition.RM },
                new FormationPosition { PlayerPosition = PlayerPosition.ST },
            };

            return positions;
        }

        public static List<FormationPosition> GetFormationPositions_4_4_2_B()
        {
            var positions = new List<FormationPosition>()
            {
                new FormationPosition { PlayerPosition = PlayerPosition.GK },
                new FormationPosition { PlayerPosition = PlayerPosition.LB },
                new FormationPosition { PlayerPosition = PlayerPosition.CB },
                new FormationPosition { PlayerPosition = PlayerPosition.CB },
                new FormationPosition { PlayerPosition = PlayerPosition.RB },
                new FormationPosition { PlayerPosition = PlayerPosition.LM },
                new FormationPosition { PlayerPosition = PlayerPosition.CDM },
                new FormationPosition { PlayerPosition = PlayerPosition.CDM },
                new FormationPosition { PlayerPosition = PlayerPosition.RM },
                new FormationPosition { PlayerPosition = PlayerPosition.ST },
                new FormationPosition { PlayerPosition = PlayerPosition.ST },

                new FormationPosition { PlayerPosition = PlayerPosition.GK },
                new FormationPosition { PlayerPosition = PlayerPosition.CB },
                new FormationPosition { PlayerPosition = PlayerPosition.CDM },
                new FormationPosition { PlayerPosition = PlayerPosition.CDM },
                new FormationPosition { PlayerPosition = PlayerPosition.LM },
                new FormationPosition { PlayerPosition = PlayerPosition.RM },
                new FormationPosition { PlayerPosition = PlayerPosition.ST },
            };

            return positions;
        }

        public static List<FormationPosition> GetFormationPositions_5_2_1_2()
        {
            var positions = new List<FormationPosition>()
            {
                new FormationPosition { PlayerPosition = PlayerPosition.GK },
                new FormationPosition { PlayerPosition = PlayerPosition.LB },
                new FormationPosition { PlayerPosition = PlayerPosition.CB },
                new FormationPosition { PlayerPosition = PlayerPosition.CB },
                new FormationPosition { PlayerPosition = PlayerPosition.CB },
                new FormationPosition { PlayerPosition = PlayerPosition.RB },
                new FormationPosition { PlayerPosition = PlayerPosition.CM },
                new FormationPosition { PlayerPosition = PlayerPosition.CM },
                new FormationPosition { PlayerPosition = PlayerPosition.CAM },
                new FormationPosition { PlayerPosition = PlayerPosition.ST },
                new FormationPosition { PlayerPosition = PlayerPosition.ST },

                new FormationPosition { PlayerPosition = PlayerPosition.GK },
                new FormationPosition { PlayerPosition = PlayerPosition.CB },
                new FormationPosition { PlayerPosition = PlayerPosition.CB },
                new FormationPosition { PlayerPosition = PlayerPosition.CM },
                new FormationPosition { PlayerPosition = PlayerPosition.CM },
                new FormationPosition { PlayerPosition = PlayerPosition.CAM },
                new FormationPosition { PlayerPosition = PlayerPosition.ST },
            };

            return positions;
        }

        public static List<FormationPosition> GetFormationPositions_5_2_2_1()
        {
            var positions = new List<FormationPosition>()
            {
                new FormationPosition { PlayerPosition = PlayerPosition.GK },
                new FormationPosition { PlayerPosition = PlayerPosition.LB },
                new FormationPosition { PlayerPosition = PlayerPosition.CB },
                new FormationPosition { PlayerPosition = PlayerPosition.CB },
                new FormationPosition { PlayerPosition = PlayerPosition.CB },
                new FormationPosition { PlayerPosition = PlayerPosition.RB },
                new FormationPosition { PlayerPosition = PlayerPosition.CM },
                new FormationPosition { PlayerPosition = PlayerPosition.CM },
                new FormationPosition { PlayerPosition = PlayerPosition.LF },
                new FormationPosition { PlayerPosition = PlayerPosition.ST },
                new FormationPosition { PlayerPosition = PlayerPosition.RF },

                new FormationPosition { PlayerPosition = PlayerPosition.GK },
                new FormationPosition { PlayerPosition = PlayerPosition.CB },
                new FormationPosition { PlayerPosition = PlayerPosition.CB },
                new FormationPosition { PlayerPosition = PlayerPosition.CM },
                new FormationPosition { PlayerPosition = PlayerPosition.LF },
                new FormationPosition { PlayerPosition = PlayerPosition.ST },
                new FormationPosition { PlayerPosition = PlayerPosition.RF },
            };

            return positions;
        }

        public static List<FormationPosition> GetFormationPositions_5_3_2()
        {
            var positions = new List<FormationPosition>()
            {
                new FormationPosition { PlayerPosition = PlayerPosition.GK },
                new FormationPosition { PlayerPosition = PlayerPosition.LB },
                new FormationPosition { PlayerPosition = PlayerPosition.CB },
                new FormationPosition { PlayerPosition = PlayerPosition.CB },
                new FormationPosition { PlayerPosition = PlayerPosition.CB },
                new FormationPosition { PlayerPosition = PlayerPosition.RB },
                new FormationPosition { PlayerPosition = PlayerPosition.CM },
                new FormationPosition { PlayerPosition = PlayerPosition.CM },
                new FormationPosition { PlayerPosition = PlayerPosition.CM },
                new FormationPosition { PlayerPosition = PlayerPosition.ST },
                new FormationPosition { PlayerPosition = PlayerPosition.ST },

                new FormationPosition { PlayerPosition = PlayerPosition.GK },
                new FormationPosition { PlayerPosition = PlayerPosition.CB },
                new FormationPosition { PlayerPosition = PlayerPosition.CB },
                new FormationPosition { PlayerPosition = PlayerPosition.CM },
                new FormationPosition { PlayerPosition = PlayerPosition.CM },
                new FormationPosition { PlayerPosition = PlayerPosition.ST },
                new FormationPosition { PlayerPosition = PlayerPosition.ST },
            };

            return positions;
        }

        private static void AddFormationPositionsCommonData(List<FormationPosition> positions)
        {
            for (int i = 0; i < 18; i++)
            {
                if (i < 11)
                {
                    positions[i].FormationPositionType = FormationPositionType.Start;
                }
                else if (i < 18)
                {
                    positions[i].FormationPositionType = FormationPositionType.Bench;
                }
                else
                {
                    positions[i].FormationPositionType = FormationPositionType.Reserve;
                }
            }
        }

        #endregion

        public static Formation GetRandomFormation()
        {
            var values = Enum.GetValues(typeof(Formation));
            var random = new Random();
            var formation = (Formation)values.GetValue(random.Next(values.Length));

            return formation;
        }
    }
}
