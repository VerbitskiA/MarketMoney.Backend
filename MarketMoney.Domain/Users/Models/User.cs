using MarketMoney.Domain.Cabinets.Models;

namespace MarketMoney.Domain.Users.Models;

public class User
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string Email { get; set; }
    public bool IsActive { get; set; }
    public string RegisterDate { get; set; }
    public virtual ICollection<Cabinet> Cabinets { get; set; }
}