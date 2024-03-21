using MarketMoney.Domain.Cabinets.Models;
using MarketMoney.Domain.Common;
using MarketMoney.Domain.Users.Models;
using Microsoft.EntityFrameworkCore;

namespace MarketMoney.Data.InMemory;

public class MarketMoneyContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Cabinet> Cabinets { get; set; }

    public MarketMoneyContext()
    {
        Database.EnsureCreated();
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("MMDB");
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
            new User { 
                Id = MmContstants.MockUserId, 
                FirstName = "Дмитрий", 
                IsActive = true, 
                Email = "some_test_email@mail.ru", 
                RegisterDate = DateTime.Now.ToShortDateString()
            }
        );
        
        modelBuilder.Entity<Cabinet>().HasData(
            new Cabinet
            {
                Id = Guid.NewGuid(),
                Title = "Test cabinet",
                ApiKey = "test-api-key",
                CabinetStatus = CabinetStatus.ConnectionFailed,
                IsActive = false,
                Marketplace = Marketplace.Wildberries,
                UserId = MmContstants.MockUserId
            }
        );
    }
}