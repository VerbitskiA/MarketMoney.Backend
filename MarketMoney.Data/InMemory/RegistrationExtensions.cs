using MarketMoney.Data.InMemory.Repositories;
using MarketMoney.Domain.Cabinets.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MarketMoney.Data.InMemory;

public static class RegistrationExtensions
{
    public static IServiceCollection RegisterInMemoryDbAndRepositories(this IServiceCollection services)
    {
        services.AddDbContext<MarketMoneyContext>();

        services.AddTransient<ICabinetRepository, CabinetRepository>();

        return services;
    }
}