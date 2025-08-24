using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelAPI.Models
{
    [Table("Hotels")] // 👈 Forces EF to use the "Hotels" table
    public class Hotel
    {
        [Key] // 👈 Primary Key
        [Column("HotelId")]
        public int HotelId { get; set; }

        [Required]
        [Column("Name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Column("Location")]
        public string Location { get; set; } = string.Empty;

        [Column("Rating")]
        public int Rating { get; set; }

        [Required]
        [Column("TeamInCharge")]
        public string TeamInCharge { get; set; } = string.Empty;
    }
}
