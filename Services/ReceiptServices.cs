using lab6.Data;
using lab6.Database;
using Microsoft.EntityFrameworkCore;

namespace lab6.Services
{
    public class ReceiptServices
    {
        protected readonly DbConnection _db;
        private readonly ConsumerServices _consumerServices;
        private readonly UtilityServices _utilityServices;
        public ReceiptServices(DbConnection db)
        {
            _db = db;
            _consumerServices = new ConsumerServices(_db);
            _utilityServices = new UtilityServices(_db);
        }

        public async Task<List<Receipt>> GetReceipts()
        {
            return await _db.Receipts.Include(p => p.Consumer).Include(p => p.Utility).Include(p => p.Consumer.Address).OrderBy(p => p.Consumer.LastName).ToListAsync();
        }

        public async Task<Receipt> GetReceipt(int id)
        {
            return await _db.Receipts.FirstAsync(p => p.ID == id);
        }

        public async Task<List<Consumer>> GetConsumersFromReceipts()
        {
            return await _consumerServices.GetConsumers();
        }

        public async Task<List<Utility>> GetUtilitiesFromReceipt()
        {
            return await _utilityServices.GetUtilities();
        }
        public async Task AddReceipt(Receipt receipt)
        {
            await _db.Receipts.AddAsync(receipt);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteReceipt(Receipt receipt)
        {
            _db.Receipts.Remove(receipt);
            await _db.SaveChangesAsync();
        }
    }
}
