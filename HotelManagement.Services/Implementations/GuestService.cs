using HotelManagement.Data;
using HotelManagement.Data.Entities;
using HotelManagement.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelManagement.Services.Implementations
{
    public class GuestService : IGuestService
    {
        private readonly HotelContext _context;

        public GuestService(HotelContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Guest>> GetAllGuestsAsync()
        {
            return await _context.Guests.ToListAsync();
        }

        public async Task<Guest?> GetGuestByIdAsync(int id)
        {
            return await _context.Guests.FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task<Guest> AddGuestAsync(Guest guest)
        {
            _context.Guests.Add(guest);
            await _context.SaveChangesAsync();
            return guest;
        }

        public async Task<Guest?> UpdateGuestAsync(Guest guest)
        {
            var existing = await _context.Guests.FindAsync(guest.Id);
            if (existing == null) return null;

            _context.Entry(existing).CurrentValues.SetValues(guest);
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteGuestAsync(int id)
        {
            var guest = await _context.Guests.FindAsync(id);
            if (guest == null) return false;

            _context.Guests.Remove(guest);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
