using ErrorOr;
using MediatR;

namespace Hafen.Application.ShipApp.Commands.Delete;

public record DeleteShipCommand
(

    Guid Id

) : IRequest<ErrorOr<bool>>;