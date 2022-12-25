using lab6.Data;
using lab6.Database;
using Microsoft.EntityFrameworkCore;

namespace lab6.Services
{
    public class UtilityServices
    {
        protected readonly DbConnection _db;
        public UtilityServices(DbConnection db)
        {
            _db = db;
        }

        public async Task<List<Utility>> GetUtilities()
        {
             
            return await _db.Utilities.OrderBy(p => p.ServiceName).ToListAsync();
        }

        public async Task<Utility> GetUtility(int id)
        {
            return await _db.Utilities.FirstAsync(p => p.ID == id);
        }

        public async Task AddUtility(Utility utility)
        {
            await _db.Utilities.AddAsync(utility);
            await _db.SaveChangesAsync();
        }

        public async Task EditUtility(Utility utility)
        {
            _db.Utilities.Update(utility);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteUtility(Utility utility)
        {
            _db.Utilities.Remove(utility);
            await _db.SaveChangesAsync();
        }
    }
}
