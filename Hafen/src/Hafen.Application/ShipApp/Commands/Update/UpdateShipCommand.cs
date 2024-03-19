using ErrorOr;
using MediatR;
using Hafen.Domain.Entities;

namespace Hafen.Application.ShipApp.Commands.Update;

public record UpdateShipCommand 
(
    
    Guid Id,
    string Name,
    float Length,
    float Width,
    string Code

) : IRequest<ErrorOr<Ship>>;