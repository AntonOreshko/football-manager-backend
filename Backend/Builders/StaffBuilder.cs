using Backend.Enums;
using Backend.Models.StaffModels;

namespace Backend.Builders
{
    public static class StaffBuilder
    {
        public static HeadCoach GetHeadCoach(int level, Country country)
        {
            var employee = new HeadCoach {Country = country, Level = level};

            NameBuilder.SetPersonInfo(employee);

            return employee;
        }

        public static HeadCoachAssistent GetHeadCoachAssistent(int level, Country country)
        {
            var employee = new HeadCoachAssistent
            {
                Country = country,
                Level = level
            };

            NameBuilder.SetPersonInfo(employee);

            return employee;
        }

        public static Medic GetMedic(int level, Country country)
        {
            var employee = new Medic
            {
                Country = country,
                Level = level
            };

            NameBuilder.SetPersonInfo(employee);

            return employee;
        }

        public static Psychologist GetPsychologist(int level, Country country)
        {
            var employee = new Psychologist
            {
                Country = country,
                Level = level
            };

            NameBuilder.SetPersonInfo(employee);

            return employee;
        }

        public static Scout GetScout(int level, Country country)
        {
            var employee = new Scout
            {
                Country = country,
                Level = level
            };

            NameBuilder.SetPersonInfo(employee);

            return employee;
        }
    }
}
