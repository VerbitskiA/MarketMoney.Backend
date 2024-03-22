using MarketMoney.Domain.Cabinets.Models;
using MarketMoney.Domain.Cabinets.Repositories;
using MediatR;

namespace MarketMoney.Domain.Cabinets.Commands;

public record EditCabinetCommand(Guid CabinetId, string Title, string ApiKey) : IRequest;

public class EditCabinetCommandHandler : IRequestHandler<EditCabinetCommand>
{
    private readonly ICabinetRepository _cabinetRepository;
    
    public EditCabinetCommandHandler(ICabinetRepository cabinetRepository)
    {
        _cabinetRepository = cabinetRepository;
    }

    public async Task Handle(EditCabinetCommand request, CancellationToken cancellationToken)
    {
        var cab = await _cabinetRepository.Update(request.CabinetId, request.Title, request.ApiKey);
    }
}