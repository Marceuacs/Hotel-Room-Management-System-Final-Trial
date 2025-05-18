using HotelManagement.Data;
using HotelManagement.Data.Entities;
using HotelManagement.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelManagement.Services.Implementations
{
    public class RoomService : IRoomService
    {
        private readonly HotelContext _context;

        public RoomService(HotelContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Room>> GetAllRoomsAsync()
        {
            return await _context.Rooms.Include(r => r.Guests).ToListAsync();
        }

        public async Task<Room?> GetRoomByIdAsync(int id)
        {
            return await _context.Rooms.Include(r => r.Guests).FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Room> AddRoomAsync(Room room)
        {
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();
            return room;
        }

        public async Task<Room?> UpdateRoomAsync(Room room)
        {
            var existingRoom = await _context.Rooms.FindAsync(room.Id);
            if (existingRoom == null) return null;

            _context.Entry(existingRoom).CurrentValues.SetValues(room);
            await _context.SaveChangesAsync();
            return existingRoom;
        }

        public async Task<bool> DeleteRoomAsync(int id)
        {
            var room = await _context.Rooms.FindAsync(id);
            if (room == null) return false;

            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
