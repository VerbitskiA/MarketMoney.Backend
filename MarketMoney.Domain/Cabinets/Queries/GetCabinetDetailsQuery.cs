using MarketMoney.Domain.Cabinets.Repositories;
using MediatR;

namespace MarketMoney.Domain.Cabinets.Queries;

public record GetCabinetDetailsQuery(Guid Id) : IRequest<CabinetDetailsDto>;

public class GetCabinetDetailsQueryHandler : IRequestHandler<GetCabinetDetailsQuery, CabinetDetailsDto>
{
    private readonly ICabinetRepository _cabinetRepository;
    
    public GetCabinetDetailsQueryHandler(ICabinetRepository cabinetRepository)
    {
        _cabinetRepository = cabinetRepository;
    }

    public async Task<CabinetDetailsDto> Handle(GetCabinetDetailsQuery request, CancellationToken cancellationToken)
    {
        var details = await _cabinetRepository.GetById(request.Id);

        return new CabinetDetailsDto
        {
            Id = details.Id,
            Title = details.Title,
            Marketplace = details.Marketplace.ToString(),
            IsActive = details.IsActive ? "Активный" : "Отключён",
            ConnectionStatus = details.ConnectionStatus.ToString(),
            CreatedAt = details.CreatedAt.ToLongDateString()
        };
    }
}

public class CabinetDetailsDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Marketplace { get; set; } = string.Empty;
    public string IsActive { get; set; } = "Отключён";
    public string ConnectionStatus { get; set; } = string.Empty;
    public string CreatedAt { get; set; } = string.Empty;
}