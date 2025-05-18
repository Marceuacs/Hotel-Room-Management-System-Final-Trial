using HotelManagement.Data.DTOs;
using HotelManagement.Data.Entities;
using HotelManagement.Services.Interfaces;
using HotelRoomManagementSystem.Data.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GuestsController : ControllerBase
    {
        private readonly IGuestService _guestService;

        public GuestsController(IGuestService guestService)
        {
            _guestService = guestService;
        }

        // ✅ GET ALL
        [HttpGet]
        public async Task<IActionResult> GetAllGuests()
        {
            var guests = await _guestService.GetAllGuestsAsync();
            return Ok(guests);
        }

        // ✅ GET BY ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGuestById(int id)
        {
            var guest = await _guestService.GetGuestByIdAsync(id);
            if (guest == null)
                return NotFound();

            return Ok(guest);
        }

        // ✅ POST (CREATE)
        [HttpPost]
        public async Task<IActionResult> AddGuest([FromBody] GuestDto guestDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var guest = new Guest
            {
                FirstName = guestDto.FirstName,
                LastName = guestDto.LastName,
                DOB = guestDto.DOB,
                Address = guestDto.Address,
                Nationality = guestDto.Nationality,
                CheckInDate = guestDto.CheckInDate,
                CheckOutDate = guestDto.CheckOutDate,
                RoomId = guestDto.RoomId
            };

            await _guestService.AddGuestAsync(guest);
            return CreatedAtAction(nameof(GetGuestById), new { id = guest.Id }, guest);
        }

        // ✅ PUT (UPDATE)
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGuest(int id, [FromBody] GuestDto guestDto)
        {
            var existing = await _guestService.GetGuestByIdAsync(id);
            if (existing == null)
                return NotFound();

            existing.FirstName = guestDto.FirstName;
            existing.LastName = guestDto.LastName;
            existing.DOB = guestDto.DOB;
            existing.Address = guestDto.Address;
            existing.Nationality = guestDto.Nationality;
            existing.CheckInDate = guestDto.CheckInDate;
            existing.CheckOutDate = guestDto.CheckOutDate;
            existing.RoomId = guestDto.RoomId;

            await _guestService.UpdateGuestAsync(existing);
            return NoContent();
        }

        // ✅ DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGuest(int id)
        {
            var guest = await _guestService.GetGuestByIdAsync(id);
            if (guest == null)
                return NotFound();

            await _guestService.DeleteGuestAsync(id);
            return NoContent();
        }
    }
}
