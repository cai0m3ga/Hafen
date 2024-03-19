namespace Hafen.Contracts.ShipContracts.Create;

public record CreateShipResponse
(
    
    Guid Id,
    string Name,
    float Length,
    float Width,
    string Code

);