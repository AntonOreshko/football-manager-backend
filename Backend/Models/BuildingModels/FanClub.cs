using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models.BuildingModels
{
    [Table("FAN_CLUBS")]
    public class FanClub : Building
    {
        [Required, Column("NAME")]
        public string Name { get; set; }

        [Required, Column("FANS_COUNT")]
        public int FansCount { get; set; }
    }
}
