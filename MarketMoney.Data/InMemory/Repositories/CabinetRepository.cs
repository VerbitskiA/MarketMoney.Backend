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

    public async Task CreateCabinet(Guid ownerId, string title, string apiKey, Marketplace marketplace, ConnectionStatus connectionStatus)
    {
        var cab = new Cabinet
        {
            Title = title,
            ApiKey = apiKey,
            Marketplace = marketplace,
            IsActive = true,
            ConnectionStatus = connectionStatus,
            CreatedAt = DateTime.UtcNow,
            UserId = ownerId
        };

        await _db.AddAsync(cab);

        await _db.SaveChangesAsync();
    }

    public Task<Cabinet?> GetById(Guid id)
    {
        return _db.Cabinets.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Cabinet> Update(Guid id, string title, string apiKey)
    {
        var cab = await GetById(id);

        cab.Title = title;
        cab.ApiKey = apiKey;

        _db.Update(cab);
        await _db.SaveChangesAsync();

        return cab;
    }
}