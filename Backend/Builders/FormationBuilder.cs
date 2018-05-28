using Backend.Enums;
using Backend.Models.SquadModels;
using System;
using System.Collections.Generic;

namespace Backend.Builders
{
    public class FormationBuilder
    {
        public static FormationData GetFormationData(Squad squad, Formation formation)
        {
            var formationData = new FormationData();

            formationData.Squad = squad;
            formationData.Formation = formation;

            AddFormationPositions(formationData);

            return formationData;
        }

        public static FormationPosition GetFormationPosition(FormationData formationData, PlayerPosition playerPosition)
        {
            var formationPosition = new FormationPosition();

            formationPosition.FormationData = formationData;
            formationPosition.PlayerPosition = playerPosition;

            return formationPosition;
        }

        public static void AddFormationPositions(FormationData formationData)
        {
            switch (formationData.Formation)
            {
                case Formation.F___3_4_1_2:
                    Fill_F___3_4_1_2(formationData);
                    break;
                case Formation.F___3_4_3:
                    Fill_F___3_4_3(formationData);
                    break;
                case Formation.F___3_5_2:
                    Fill_F___3_5_2(formationData);
                    break;
                case Formation.F___4_1_2_1_2_A:
                    Fill_F___4_1_2_1_2_A(formationData);
                    break;
                case Formation.F___4_1_2_1_2_B:
                    Fill_F___4_1_2_1_2_B(formationData);
                    break;
                case Formation.F___4_2_3_1_A:
                    Fill_F___4_2_3_1_A(formationData);
                    break;
                case Formation.F___4_2_3_1_B:
                    Fill_F___4_2_3_1_B(formationData);
                    break;
                case Formation.F___4_2_2_2:
                    Fill_F___4_2_2_2(formationData);
                    break;
                case Formation.F___4_3_1_2:
                    Fill_F___4_3_1_2(formationData);
                    break;
                case Formation.F___4_3_3_A:
                    Fill_F___4_3_3_A(formationData);
                    break;
                case Formation.F___4_3_3_B:
                    Fill_F___4_3_3_B(formationData);
                    break;
                case Formation.F___4_3_3_C:
                    Fill_F___4_3_3_C(formationData);
                    break;
                case Formation.F___4_3_3_D:
                    Fill_F___4_3_3_D(formationData);
                    break;
                case Formation.F___4_4_2_A:
                    Fill_F___4_4_2_A(formationData);
                    break;
                case Formation.F___4_4_2_B:
                    Fill_F___4_4_2_B(formationData);
                    break;
                case Formation.F___5_2_1_2:
                    Fill_F___5_2_1_2(formationData);
                    break;
                case Formation.F___5_2_2_1:
                    Fill_F___5_2_2_1(formationData);
                    break;
                case Formation.F___5_3_2:
                    Fill_F___5_3_2(formationData);
                    break;
            }
        }

        #region Formations Filling

        public static void Fill_F___3_4_1_2(FormationData formationData)
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

            FillFormationPositionCommonData(positions, formationData);

            formationData.FormationPositions = positions;
        }

        public static void Fill_F___3_4_3(FormationData formationData)
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

            FillFormationPositionCommonData(positions, formationData);

            formationData.FormationPositions = positions;
        }

        public static void Fill_F___3_5_2(FormationData formationData)
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

            FillFormationPositionCommonData(positions, formationData);

            formationData.FormationPositions = positions;
        }

        public static void Fill_F___4_1_2_1_2_A(FormationData formationData)
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

            FillFormationPositionCommonData(positions, formationData);

            formationData.FormationPositions = positions;
        }

        public static void Fill_F___4_1_2_1_2_B(FormationData formationData)
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

            FillFormationPositionCommonData(positions, formationData);

            formationData.FormationPositions = positions;
        }

        public static void Fill_F___4_2_3_1_A(FormationData formationData)
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

            FillFormationPositionCommonData(positions, formationData);

            formationData.FormationPositions = positions;
        }

        public static void Fill_F___4_2_3_1_B(FormationData formationData)
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

            FillFormationPositionCommonData(positions, formationData);

            formationData.FormationPositions = positions;
        }

        public static void Fill_F___4_2_2_2(FormationData formationData)
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

            FillFormationPositionCommonData(positions, formationData);

            formationData.FormationPositions = positions;
        }

        public static void Fill_F___4_3_1_2(FormationData formationData)
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

            FillFormationPositionCommonData(positions, formationData);

            formationData.FormationPositions = positions;
        }

        public static void Fill_F___4_3_3_A(FormationData formationData)
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

            FillFormationPositionCommonData(positions, formationData);

            formationData.FormationPositions = positions;
        }

        public static void Fill_F___4_3_3_B(FormationData formationData)
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

            FillFormationPositionCommonData(positions, formationData);

            formationData.FormationPositions = positions;
        }

        public static void Fill_F___4_3_3_C(FormationData formationData)
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

            FillFormationPositionCommonData(positions, formationData);

            formationData.FormationPositions = positions;
        }

        public static void Fill_F___4_3_3_D(FormationData formationData)
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

            FillFormationPositionCommonData(positions, formationData);

            formationData.FormationPositions = positions;
        }

        public static void Fill_F___4_4_2_A(FormationData formationData)
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

            FillFormationPositionCommonData(positions, formationData);

            formationData.FormationPositions = positions;
        }

        public static void Fill_F___4_4_2_B(FormationData formationData)
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

            FillFormationPositionCommonData(positions, formationData);

            formationData.FormationPositions = positions;
        }

        public static void Fill_F___5_2_1_2(FormationData formationData)
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

            FillFormationPositionCommonData(positions, formationData);

            formationData.FormationPositions = positions;
        }

        public static void Fill_F___5_2_2_1(FormationData formationData)
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

            FillFormationPositionCommonData(positions, formationData);

            formationData.FormationPositions = positions;
        }

        public static void Fill_F___5_3_2(FormationData formationData)
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

            FillFormationPositionCommonData(positions, formationData);

            formationData.FormationPositions = positions;
        }

        private static void FillFormationPositionCommonData(List<FormationPosition> positions, FormationData formationData)
        {
            for (int i = 0; i < 18; i++)
            {
                positions[i].FormationData = formationData;
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
