using HotelManagement.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelManagement.Services.Interfaces
{
    public interface IGuestService
    {
        Task<IEnumerable<Guest>> GetAllGuestsAsync();
        Task<Guest?> GetGuestByIdAsync(int id);
        Task<Guest> AddGuestAsync(Guest guest);
        Task<Guest?> UpdateGuestAsync(Guest guest);
        Task<bool> DeleteGuestAsync(int id);
    }
}
