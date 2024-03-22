namespace MarketMoney.Domain.Marketplaces.Common;

public interface IConnectable
{
    Task<bool> CheckConnection();
}