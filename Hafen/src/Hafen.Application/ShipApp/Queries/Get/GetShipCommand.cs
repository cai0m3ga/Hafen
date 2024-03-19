using ErrorOr;
using MediatR;
using Hafen.Domain.Entities;

namespace Hafen.Application.ShipApp.Queries.Get;

public record GetShipCommand
(

    Guid Id

) : IRequest<ErrorOr<Ship>>;