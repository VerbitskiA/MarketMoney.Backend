using MarketMoney.Domain.Cabinets.Models;

namespace MarketMoney.Domain.Cabinets.Repositories;

public interface ICabinetRepository
{
    Task<List<Cabinet>> GetCabinetsByUserId(Guid userId);

    Task CreateCabinet(Guid ownerId, string title, string apiKey, Marketplace marketplace, ConnectionStatus connectionStatus);

    Task<Cabinet?> GetById(Guid id);

    Task<Cabinet> Update(Guid id, string title, string apiKey);
}