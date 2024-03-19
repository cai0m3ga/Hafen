using ErrorOr;
using Hafen.Application.Common.Interfaces.Persistence;
using Hafen.Domain.Entities;
using MediatR;

namespace Hafen.Application.ShipApp.Commands.Create;

public class CreateShipCommandHandler : IRequestHandler<CreateShipCommand, ErrorOr<Ship>>
{

    private readonly IShipRepository _shipRepository;

    public CreateShipCommandHandler(IShipRepository shipRepository)
    {

        _shipRepository = shipRepository;

    }

    public async Task<ErrorOr<Ship>> Handle(CreateShipCommand request, CancellationToken cancellationToken)
    {

        await Task.CompletedTask;

        var newEntity = new Ship(

            Guid.NewGuid(),
            request.Name,
            request.Length,
            request.Width,
            request.Code
            
        );

        return _shipRepository.Add(newEntity);

    }

}