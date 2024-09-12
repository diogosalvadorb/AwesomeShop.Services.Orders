using AwesomeShop.Services.Core.Entities;
using AwesomeShop.Services.Core.Repository;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace AwesomeShop.Services.Infrastructure.Persistence.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IMongoCollection<Order> _collection;
        public OrderRepository(IMongoDatabase mongoDatabase)
        {
            _collection = mongoDatabase.GetCollection<Order>("orders");
        }

        public async Task AddAsync(Order order)
        {
            await _collection.InsertOneAsync(order);
        }

        public async Task<Order> GetByIdAsync(Guid id)
        {
            return await _collection.Find(x => x.Id == id).SingleOrDefaultAsync();
        }

        public async Task Update(Order order)
        {
            await _collection.ReplaceOneAsync(c => c.Id == order.Id, order);
        }
    }
}
