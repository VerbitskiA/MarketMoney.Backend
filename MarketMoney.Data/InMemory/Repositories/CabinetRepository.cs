using MarketMoney.Domain.Cabinets.Models;
using MarketMoney.Domain.Cabinets.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MarketMoney.Data.InMemory.Repositories;

public class CabinetRepository : ICabinetRepository
{
    private readonly MarketMoneyContext _db;
    
    public CabinetRepository(MarketMoneyContext db)
    {
        _db = db;
    }
    
    public Task<List<Cabinet>> GetCabinetsByUserId(Guid userId)
    {
        return _db.Cabinets.Where(x=>x.UserId == userId).ToListAsync();
    }
}