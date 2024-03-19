namespace Hafen.Contracts.ShipContracts.Get;

public record GetShipReponse
(
    
    Guid Id,
    string Name,
    float Length,
    float Width,
    string Code

);