using ErrorOr;
using Hafen.Application.Common.Interfaces.Persistence;
using MediatR;

namespace Hafen.Application.ShipApp.Commands.Delete;

public class DeleteShipCommandHandler : IRequestHandler<DeleteShipCommand, ErrorOr<bool>>
{

    private readonly IShipRepository _shipRepository;

    public DeleteShipCommandHandler(IShipRepository shipRepository)
    {

        _shipRepository = shipRepository;

    }

    public async Task<ErrorOr<bool>> Handle(DeleteShipCommand request, CancellationToken cancellationToken)
    {

        await Task.CompletedTask;

        var response = _shipRepository.Delete(request.Id);

        if (!response)
            return Error.Validation("InvalidId", "Invalid Id");

        return response;

    }

}