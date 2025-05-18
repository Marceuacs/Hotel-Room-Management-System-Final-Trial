using HotelManagement.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelManagement.Data.Repositories
{
    public interface IGuestRepository
    {
        Task<IEnumerable<Guest>> GetAllAsync();
        Task<Guest?> GetByIdAsync(int id);
        Task AddAsync(Guest guest);
        Task UpdateAsync(Guest guest);
        Task DeleteAsync(int id);
    }
}
