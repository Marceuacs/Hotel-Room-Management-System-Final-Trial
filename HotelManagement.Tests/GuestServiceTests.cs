using HotelManagement.Data.Entities;
using HotelManagement.Data.Repositories;
using HotelManagement.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelManagement.Services.Implementations
{
    public class GuestService : IGuestService
    {
        private readonly IGuestRepository _guestRepository;

        public GuestService(IGuestRepository guestRepository)
        {
            _guestRepository = guestRepository;
        }

        public async Task<IEnumerable<Guest>> GetAllGuestsAsync()
        {
            return await _guestRepository.GetAllAsync();
        }

        public async Task<Guest?> GetGuestByIdAsync(int id)
        {
            return await _guestRepository.GetByIdAsync(id);
        }

        public async Task<Guest> AddGuestAsync(Guest guest)
        {
            await _guestRepository.AddAsync(guest);
            return guest;
        }

        public async Task<Guest?> UpdateGuestAsync(Guest guest)
        {
            await _guestRepository.UpdateAsync(guest);
            return guest;
        }

        public async Task<bool> DeleteGuestAsync(int id)
        {
            await _guestRepository.DeleteAsync(id);
            return true;
        }
    }
}
