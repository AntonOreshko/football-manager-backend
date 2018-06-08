using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models.BuildingModels;

namespace Backend.Builders.Buildings
{
    public class MedicalCenterBuilder
    {
        public static MedicalCenter GetMedicalCenter()
        {
            return new MedicalCenter()
            {
                Level = 1
            };
        }
    }
}
