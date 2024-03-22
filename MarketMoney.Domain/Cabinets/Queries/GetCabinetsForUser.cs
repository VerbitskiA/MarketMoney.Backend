using MarketMoney.Domain.Cabinets.Repositories;
using MediatR;

namespace MarketMoney.Domain.Cabinets.Queries;

public record GetCabinetsForUserQuery(Guid UserId) : IRequest<List<CabinetDto>>;

public class GetCabinetsForUserHandler : IRequestHandler<GetCabinetsForUserQuery, List<CabinetDto>>
{
    private readonly ICabinetRepository _cabinetRepository;
    
    public GetCabinetsForUserHandler(ICabinetRepository cabinetRepository)
    {
        _cabinetRepository = cabinetRepository;
    }
    
    public async Task<List<CabinetDto>> Handle(GetCabinetsForUserQuery request, CancellationToken cancellationToken)
    {
        var cabs = await _cabinetRepository.GetCabinetsByUserId(request.UserId);

        return cabs.Select(x => new CabinetDto
        {
            Id = x.Id.ToString(),
            Title = x.Title,
            Marketplace = x.Marketplace.ToString(),
            Status = x.IsActive ? "Активный" : "Отключён",
            LastUpdate = "Не загружались"
        }).ToList();
    }
}

public class CabinetDto
{
    public string Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Marketplace { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string LastUpdate { get; set; } = string.Empty;
}