using Backend.Enums;
using Backend.Models.SquadModels;
using System;
using System.Collections.Generic;

namespace Backend.Builders
{
    public class FormationBuilder
    {
        public static FormationPosition GetFormationPosition(PlayerPosition playerPosition)
        {
            var formationPosition = new FormationPosition
            {
                PlayerPosition = playerPosition
            };

            return formationPosition;
        }

        public static void AddFormationPositions(Squad squad)
        {
            switch (squad.Formation)
            {
                case Formation.F___3_4_1_2:
                    GetFormationPositions_3_4_1_2(squad);
                    break;
                case Formation.F___3_4_3:
                    GetFormationPositions_3_4_3(squad);
                    break;
                case Formation.F___3_5_2:
                    GetFormationPositions_3_5_2(squad);
                    break;
                case Formation.F___4_1_2_1_2_A:
                    GetFormationPositions_4_1_2_1_2_A(squad);
                    break;
                case Formation.F___4_1_2_1_2_B:
                    GetFormationPositions_4_1_2_1_2_B(squad);
                    break;
                case Formation.F___4_2_3_1_A:
                    GetFormationPositions_4_2_3_1_A(squad);
                    break;
                case Formation.F___4_2_3_1_B:
                    Fill_F___4_2_3_1_B(squad);
                    break;
                case Formation.F___4_2_2_2:
                    Fill_F___4_2_2_2(squad);
                    break;
                case Formation.F___4_3_1_2:
                    Fill_F___4_3_1_2(squad);
                    break;
                case Formation.F___4_3_3_A:
                    Fill_F___4_3_3_A(squad);
                    break;
                case Formation.F___4_3_3_B:
                    Fill_F___4_3_3_B(squad);
                    break;
                case Formation.F___4_3_3_C:
                    Fill_F___4_3_3_C(squad);
                    break;
                case Formation.F___4_3_3_D:
                    Fill_F___4_3_3_D(squad);
                    break;
                case Formation.F___4_4_2_A:
                    Fill_F___4_4_2_A(squad);
                    break;
                case Formation.F___4_4_2_B:
                    Fill_F___4_4_2_B(squad);
                    break;
                case Formation.F___5_2_1_2:
                    Fill_F___5_2_1_2(squad);
                    break;
                case Formation.F___5_2_2_1:
                    Fill_F___5_2_2_1(squad);
                    break;
                case Formation.F___5_3_2:
                    Fill_F___5_3_2(squad);
                    break;
            }
        }

        #region Formations Filling

        public static void GetFormationPositions_3_4_1_2(Squad squad)
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

            FillFormationPositionCommonData(positions, squad);

            squad.FormationPositions = positions;
        }

        public static void GetFormationPositions_3_4_3(Squad squad)
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

            FillFormationPositionCommonData(positions, squad);

            squad.FormationPositions = positions;
        }

        public static void GetFormationPositions_3_5_2(Squad squad)
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

            FillFormationPositionCommonData(positions, squad);

            squad.FormationPositions = positions;
        }

        public static void GetFormationPositions_4_1_2_1_2_A(Squad squad)
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

            FillFormationPositionCommonData(positions, squad);

            squad.FormationPositions = positions;
        }

        public static void GetFormationPositions_4_1_2_1_2_B(Squad squad)
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

            FillFormationPositionCommonData(positions, squad);

            squad.FormationPositions = positions;
        }

        public static void GetFormationPositions_4_2_3_1_A(Squad squad)
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

            FillFormationPositionCommonData(positions, squad);

            squad.FormationPositions = positions;
        }

        public static void Fill_F___4_2_3_1_B(Squad squad)
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

            FillFormationPositionCommonData(positions, squad);

            squad.FormationPositions = positions;
        }

        public static void Fill_F___4_2_2_2(Squad squad)
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

            FillFormationPositionCommonData(positions, squad);

            squad.FormationPositions = positions;
        }

        public static void Fill_F___4_3_1_2(Squad squad)
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

            FillFormationPositionCommonData(positions, squad);

            squad.FormationPositions = positions;
        }

        public static void Fill_F___4_3_3_A(Squad squad)
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

            FillFormationPositionCommonData(positions, squad);

            squad.FormationPositions = positions;
        }

        public static void Fill_F___4_3_3_B(Squad squad)
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

            FillFormationPositionCommonData(positions, squad);

            squad.FormationPositions = positions;
        }

        public static void Fill_F___4_3_3_C(Squad squad)
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

            FillFormationPositionCommonData(positions, squad);

            squad.FormationPositions = positions;
        }

        public static void Fill_F___4_3_3_D(Squad squad)
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

            FillFormationPositionCommonData(positions, squad);

            squad.FormationPositions = positions;
        }

        public static void Fill_F___4_4_2_A(Squad squad)
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

            FillFormationPositionCommonData(positions, squad);

            squad.FormationPositions = positions;
        }

        public static void Fill_F___4_4_2_B(Squad squad)
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

            FillFormationPositionCommonData(positions, squad);

            squad.FormationPositions = positions;
        }

        public static void Fill_F___5_2_1_2(Squad squad)
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

            FillFormationPositionCommonData(positions, squad);

            squad.FormationPositions = positions;
        }

        public static void Fill_F___5_2_2_1(Squad squad)
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

            FillFormationPositionCommonData(positions, squad);

            squad.FormationPositions = positions;
        }

        public static void Fill_F___5_3_2(Squad squad)
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

            FillFormationPositionCommonData(positions, squad);

            squad.FormationPositions = positions;
        }

        private static void FillFormationPositionCommonData(List<FormationPosition> positions, Squad squad)
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
            Array values = Enum.GetValues(typeof(Formation));
            Random random = new Random();
            Formation formation = (Formation)values.GetValue(random.Next(values.Length));

            return formation;
        }
    }
}
