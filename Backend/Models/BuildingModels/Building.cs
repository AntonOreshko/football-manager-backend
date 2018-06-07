using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models.BuildingModels
{
    [Table("BUILDINGS")]
    public class Building
    {
        [Key, Column("ID")]
        public int Id { get; set; }

        [Required, Column("LEVEL"), Range(1, 5)]
        public int Level { get; set; }

        [ForeignKey(nameof(Id))]
        public Club Club { get; set; }
    }
}
