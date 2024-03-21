using MarketMoney.Domain.Cabinets.Models;

namespace MarketMoney.Domain.Cabinets.Repositories;

public interface ICabinetRepository
{
    Task<List<Cabinet>> GetCabinetsByUserId(Guid userId);
}