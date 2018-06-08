using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models.BuildingModels
{
    [Table("BUILDINGS")]
    public class Building
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column("ID")]
        public int Id { get; set; }

        [Required, Column("LEVEL"), Range(1, 5)]
        public int Level { get; set; }

        [Required, Column("CLUB_ID")]
        public int ClubId { get; set; }

        [ForeignKey(nameof(ClubId))]
        public virtual Club Club { get; set; }
    }
}
