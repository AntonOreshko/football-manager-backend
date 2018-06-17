using System.Collections.Generic;
using DomainModels.Enums;

namespace BusinessLayer.Mappers
{
    public class ConstitutionMapper
    {
        public float BoostValue { get; set; }

        public List<ConstitutionItem> Items { get; set; }
    }

    public class ConstitutionItem
    {
        public HeightType HeightType { get; set; }

        public BodyType BodyType { get; set; }

        public Dictionary<string, int> StatsBoosters { get; set; }
    }
}
