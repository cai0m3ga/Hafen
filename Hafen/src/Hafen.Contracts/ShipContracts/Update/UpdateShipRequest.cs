namespace Hafen.Contracts.ShipContracts.Create;

public record UpdateShipRequest
(

    Guid Id,
    string Name,
    float Length,
    float Width,
    string Code

);