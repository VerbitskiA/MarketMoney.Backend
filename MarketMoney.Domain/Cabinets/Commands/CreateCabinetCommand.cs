using MarketMoney.Domain.Cabinets.Models;
using MarketMoney.Domain.Cabinets.Repositories;
using MediatR;

namespace MarketMoney.Domain.Cabinets.Commands;

public record CreateCabinetCommand(Guid OwnerId, string Title, string ApiKey) : IRequest;

public class CreateCabinetCommandHandler : IRequestHandler<CreateCabinetCommand>
{
    private readonly ICabinetRepository _cabinetRepository;
    
    public CreateCabinetCommandHandler(ICabinetRepository cabinetRepository)
    {
        _cabinetRepository = cabinetRepository;
    }
    
    public async Task Handle(CreateCabinetCommand request, CancellationToken cancellationToken)
    {
        // using var client = new HttpClient();
        // var url = "https://statistics-api.wildberries.ru/api/v1/supplier/sales";
        // client.DefaultRequestHeaders.Add("Authorization", "Bearer " + request.ApiKey);
        // var response = await client.GetStringAsync(url);
        
        await _cabinetRepository.CreateCabinet(request.OwnerId, request.Title, request.ApiKey, Marketplace.Wildberries,
            ConnectionStatus.None);
    }
}