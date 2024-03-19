using ErrorOr;
using Hafen.Application.Common.Interfaces.Persistence;
using Hafen.Domain.Entities;
using MediatR;

namespace Hafen.Application.ShipApp.Commands.Update;

public class UpdateShipCommandHandler : IRequestHandler<UpdateShipCommand, ErrorOr<Ship>>
{

    private readonly IShipRepository _shipRepository;

    public UpdateShipCommandHandler(IShipRepository shipRepository)
    {

        _shipRepository = shipRepository;

    }

    public async Task<ErrorOr<Ship>> Handle(UpdateShipCommand request, CancellationToken cancellationToken)
    {

        await Task.CompletedTask;

        var newEntity = new Ship(

            request.Id,
            request.Name,
            request.Length,
            request.Width,
            request.Code

        );

        var response = _shipRepository.Update(newEntity);

        if (response is null)
            return Error.Validation("InvalidId", "Invalid Id");

        return response;

    }

}