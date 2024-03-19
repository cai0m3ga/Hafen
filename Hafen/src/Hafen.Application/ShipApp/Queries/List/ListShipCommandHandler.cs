using ErrorOr;
using Hafen.Application.Common.Interfaces.Persistence;
using Hafen.Domain.Entities;
using MediatR;

namespace Hafen.Application.ShipApp.Queries.List;

public class ListShipCommandHandler : IRequestHandler<ListShipCommand, ErrorOr<List<Ship>>>
{

    private readonly IShipRepository _shipRepository;

    public ListShipCommandHandler(IShipRepository shipRepository)
    {

        _shipRepository = shipRepository;

    }

    public async Task<ErrorOr<List<Ship>>> Handle(ListShipCommand request, CancellationToken cancellationToken)
    {

        await Task.CompletedTask;
       
        return _shipRepository.List();

    }

}