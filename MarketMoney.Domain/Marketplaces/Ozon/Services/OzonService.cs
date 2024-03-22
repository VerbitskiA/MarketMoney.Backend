using MarketMoney.Domain.Marketplaces.Common;

namespace MarketMoney.Domain.Marketplaces.Ozon.Services;

public class OzonService : IOzonService, IConnectable
{
    public Task<bool> CheckConnection()
    {
        throw new NotImplementedException();
    }
}