using Backend.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models.StaffModels
{
    [Table("EMPLOYEES")]
    public class Employee
    {
        [Key, Column("ID")]
        public int Id { get; set; }

        [Required, Column("FIRST_NAME"), MaxLength(64)]
        public string FirstName { get; set; }

        [Required, Column("LAST_NAME"), MaxLength(64)]
        public string LastName { get; set; }

        [Required, Column("COUNTRY")]
        public Country Country { get; set; }

        [Required, Column("LEVEL"), Range(1, 5)]
        public int Level { get; set; }
    }
}
