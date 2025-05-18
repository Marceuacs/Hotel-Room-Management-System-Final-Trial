using HotelManagement.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelManagement.Services.Interfaces
{
    public interface IRoomService
    {
        Task<IEnumerable<Room>> GetAllRoomsAsync();
        Task<Room?> GetRoomByIdAsync(int id);
        Task<Room> AddRoomAsync(Room room);
        Task<Room?> UpdateRoomAsync(Room room);
        Task<bool> DeleteRoomAsync(int id);
    }
}
