using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models.BuildingModels
{
    [Table("STADIUMS")]
    public class Stadium : Building
    {
        [Required, Column("NAME")]
        public string Name { get; set; }
    }
}
