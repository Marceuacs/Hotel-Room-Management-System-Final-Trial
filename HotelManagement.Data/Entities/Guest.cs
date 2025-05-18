using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HotelManagement.Data.Entities
{
    public class Guest
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(200)]
        public string FirstName { get; set; } = string.Empty;

        [Required, MaxLength(400)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public DateTime DOB { get; set; }

        [Required, MaxLength(600)]
        public string Address { get; set; } = string.Empty;

        [Required]
        public string Nationality { get; set; } = string.Empty;

        [Required]
        public DateTime CheckInDate { get; set; }

        [Required]
        public DateTime CheckOutDate { get; set; }

        [ForeignKey("Room")]
        public int RoomId { get; set; }

        [JsonIgnore] // ✅ Prevents Swagger binding issues
        public Room? Room { get; set; }
    }
}
