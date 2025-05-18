﻿using HotelManagement.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelManagement.Data.Repositories
{
    public interface IRoomRepository
    {
        Task<IEnumerable<Room>> GetAllAsync();
        Task<Room?> GetByIdAsync(int id);
        Task AddAsync(Room room);
        Task UpdateAsync(Room room);
        Task DeleteAsync(int id);
    }
}
