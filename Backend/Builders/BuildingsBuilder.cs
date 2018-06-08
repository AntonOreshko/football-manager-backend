using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models.BuildingModels;

namespace Backend.Builders
{
    public static class BuildingsBuilder
    {
        public static Academy GetAcademy()
        {
            return new Academy()
            {
                Level = 1
            };
        }

        public static FanClub GetFanClub()
        {
            return new FanClub()
            {
                Level = 1
            };
        }

        public static MedicalCenter GetMedicalCenter()
        {
            return new MedicalCenter()
            {
                Level = 1
            };
        }

        public static Stadium GetStadium()
        {
            return new Stadium()
            {
                Level = 1
            };
        }

        public static TrainingCenter GetTrainingCenter()
        {
            return new TrainingCenter()
            {
                Level = 1
            };
        }
    }
}
