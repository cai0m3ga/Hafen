using ErrorOr;
using MediatR;
using Hafen.Domain.Entities;

namespace Hafen.Application.ShipApp.Queries.List;

public record ListShipCommand 
() : IRequest<ErrorOr<List<Ship>>>;