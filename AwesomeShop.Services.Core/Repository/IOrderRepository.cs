using AwesomeShop.Services.Core.Entities;
using System;
using System.Threading.Tasks;

namespace AwesomeShop.Services.Core.Repository
{
    public interface IOrderRepository
    {
        Task<Order> GetByIdAsync(Guid id);
        Task AddAsync(Order order);
        Task UpdateAsync(Order order);
    }
}
