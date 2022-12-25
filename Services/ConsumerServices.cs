using lab6.Data;
using lab6.Database;
using Microsoft.EntityFrameworkCore;

namespace lab6.Services
{
    public class ConsumerServices
    {
        protected readonly DbConnection _db;
        private readonly AddressServices _addressService;
        public ConsumerServices(DbConnection db)
        {
            _db = db;
            _addressService = new AddressServices(_db);
        }

        public async Task<List<Consumer>> GetConsumers()
        {
            return await _db.Consumers.Include(p => p.Address).ToListAsync();
        }

        public async Task<List<Address>> GetAddressesFromConsumers()
        {
            return await _addressService.GetAddresses();
        }

        public async Task<Consumer> GetConsumer(int id)
        {
            return await _db.Consumers.FirstAsync(p => p.ID == id);
        }

        public async Task AddConsumer(Consumer consumer)
        {
            await _db.Consumers.AddAsync(consumer);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteConsumer(Consumer consumer)
        {
            _db.Consumers.Remove(consumer);
            await _db.SaveChangesAsync();
        }
    }
}
