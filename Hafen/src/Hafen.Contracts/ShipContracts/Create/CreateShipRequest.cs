namespace Hafen.Contracts.ShipContracts.Create;

public record CreateShipRequest
(

    string Name,
    float Length,
    float Width,
    string Code

);