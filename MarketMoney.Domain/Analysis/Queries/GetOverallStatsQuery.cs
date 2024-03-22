using MarketMoney.Domain.Cabinets.Queries;
using MarketMoney.Domain.Cabinets.Repositories;
using MediatR;

namespace MarketMoney.Domain.Analysis.Queries;

public record GetOverallStatsQuery(Guid UserId) : IRequest<OverallStatsDto>;

public class GetOverallStatsQueryHandler : IRequestHandler<GetOverallStatsQuery, OverallStatsDto>
{
    private readonly ICabinetRepository _cabinetRepository;
    
    public GetOverallStatsQueryHandler(ICabinetRepository cabinetRepository)
    {
        _cabinetRepository = cabinetRepository;
    }


    public async Task<OverallStatsDto> Handle(GetOverallStatsQuery request, CancellationToken cancellationToken)
    {
        var cabinets = await _cabinetRepository.GetCabinetsByUserId(request.UserId);

        return new OverallStatsDto
        {
            TotalCabinets = cabinets.Count
        };
    }
}

public class OverallStatsDto
{
    public int TotalCabinets { get; set; }
}
