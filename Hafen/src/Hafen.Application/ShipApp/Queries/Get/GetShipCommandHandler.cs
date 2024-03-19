using ErrorOr;
using FluentValidation.TestHelper;
using Hafen.Application.Common.Interfaces.Persistence;
using Hafen.Domain.Entities;
using MediatR;

namespace Hafen.Application.ShipApp.Queries.Get;

public class GetShipCommandHandler : IRequestHandler<GetShipCommand, ErrorOr<Ship>>
{

    private readonly IShipRepository _shipRepository;

    public GetShipCommandHandler(IShipRepository shipRepository)
    {

        _shipRepository = shipRepository;

    }

    public async Task<ErrorOr<Ship>> Handle(GetShipCommand request, CancellationToken cancellationToken)
    {

        await Task.CompletedTask;

        var response = _shipRepository.GetById(request.Id);

        if (response is null)
            return Error.Validation("InvalidId", "Invalid Id");

        return response;

    }

}