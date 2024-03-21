using MarketMoney.Domain.Users.Models;

namespace MarketMoney.Domain.Cabinets.Models;

public class Cabinet
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public Marketplace Marketplace { get; set; }
    public bool IsActive { get; set; }
    public string ApiKey { get; set; }
    public CabinetStatus CabinetStatus { get; set; }
    
    public Guid UserId { get; set; }
    public User User { get; set; }
}