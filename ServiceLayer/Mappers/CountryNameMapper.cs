using System.Collections.Generic;
using DomainModels.Enums;

namespace BusinessLayer.Mappers
{
    public class CountryNameMapper
    {
        public Dictionary<Country, List<Country>> NamesGenerationKeys { get; set; }
    }
}
