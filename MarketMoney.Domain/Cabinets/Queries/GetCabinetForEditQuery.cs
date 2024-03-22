using MarketMoney.Domain.Cabinets.Repositories;
using MediatR;

namespace MarketMoney.Domain.Cabinets.Queries;

public record GetCabinetForEditQuery(string CabinetId) : IRequest<EditCabinetDto>;

public class GetCabinetForEditQueryHandler : IRequestHandler<GetCabinetForEditQuery, EditCabinetDto>
{
    private readonly ICabinetRepository _cabinetRepository;
    
    public GetCabinetForEditQueryHandler(ICabinetRepository cabinetRepository)
    {
        _cabinetRepository = cabinetRepository;
    }

    public async Task<EditCabinetDto> Handle(GetCabinetForEditQuery request, CancellationToken cancellationToken)
    {
        var cab = await _cabinetRepository.GetById(Guid.Parse(request.CabinetId));

        return new EditCabinetDto
        {
            Id = cab.Id,
            ApiKey = string.Empty,
            Title = cab.Title,
            Marketplace = cab.Marketplace.ToString()
        };
    }
}

public class EditCabinetDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string ApiKey { get; set; } = string.Empty;
    public string Marketplace { get; set; } = string.Empty;
}