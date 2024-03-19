using ErrorOr;
using MediatR;
using Hafen.Domain.Entities;

namespace Hafen.Application.ShipApp.Commands.Create;

public record CreateShipCommand 
(

    string Name,
    float Length,
    float Width,
    string Code

) : IRequest<ErrorOr<Ship>>;