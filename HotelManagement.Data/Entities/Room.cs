using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HotelManagement.Data.Entities
{
    public class Room
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Number { get; set; } = null!;

        [Required]
        public int Floor { get; set; }

        [Required]
        public string Type { get; set; } = null!;

        [JsonIgnore] // ✅ Prevents recursion and clutter in Swagger
        public ICollection<Guest> Guests { get; set; } = new List<Guest>();
    }
}
