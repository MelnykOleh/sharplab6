using lab6.Data;
using lab6.Database;
using Microsoft.EntityFrameworkCore;

namespace lab6.Services
{
    public class AddressServices
    {
        protected readonly DbConnection _db;

        public AddressServices(DbConnection db)
        {
            _db = db;
        }

        public async Task<List<Address>> GetAddresses()
        {
            return await _db.Addresses.OrderBy(p => p.Street).ToListAsync();
        }

        public async Task<Address> GetAddress(int id)
        {
            return await _db.Addresses.FirstAsync(p => p.ID == id);
        }

        public async Task AddAddress(Address address)
        {
            await _db.Addresses.AddAsync(address);
            await _db.SaveChangesAsync();
        }

        public async Task EditAddress(Address address)
        {
            _db.Addresses.Update(address);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAddress(Address address)
        {
            _db.Addresses.Remove(address);
            await _db.SaveChangesAsync(); 
        }
    }
}
