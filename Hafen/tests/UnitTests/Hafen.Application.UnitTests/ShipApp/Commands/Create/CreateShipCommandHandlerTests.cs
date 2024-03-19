using FluentValidation;
using Hafen.Application.ShipApp.Commands.Create;

namespace Hafen.Application.UnitTests.ShipApp.Commands.Create;

public class CreateShipCommandHandlerTests
{

    private AbstractValidator<CreateShipCommand> _validator = new CreateShipCommandValidator();
    private static List<string> ConvertErrors(FluentValidation.Results.ValidationResult result)
    {

        return result.Errors
                    .Select(e => e.ErrorMessage)
                    .ToList();

    }

    [Fact]
    public void Ship_CreateCommand_InvalidName()
    {

        var shipCommand = new CreateShipCommand("", 1, 2, "AAAA-1111-A1");
        var validation = _validator.Validate(shipCommand);
        var errors = ConvertErrors(validation);

        Assert.Equal("'Name' must not be empty.", errors.First());
        Assert.False(validation.IsValid);

    }

    [Fact]
    public void Ship_CreateCommand_InvalidLength()
    {

        var shipCommand = new CreateShipCommand("Ship Name", 0, 2, "AAAA-1111-A1");
        var validation = _validator.Validate(shipCommand);
        var errors = ConvertErrors(validation);


        Assert.Equal("'Length' must be greater than '0'.", errors.First());
        Assert.False(validation.IsValid);

    }

    [Fact]
    public void Ship_CreateCommand_InvalidWidth()
    {

        var shipCommand = new CreateShipCommand("Ship Name", 2, 0, "AAAA-1111-A1");
        var validation = _validator.Validate(shipCommand);
        var errors = ConvertErrors(validation);


        Assert.Equal("'Width' must be greater than '0'.", errors.First());
        Assert.False(validation.IsValid);

    }

    [Fact]
    public void Ship_CreateCommand_EmptyCode()
    {

        var shipCommand = new CreateShipCommand("Ship Name", 2, 2, "");
        var validation = _validator.Validate(shipCommand);
        var errors = ConvertErrors(validation);


        Assert.Equal("'Code' must not be empty.", errors.First());
        Assert.False(validation.IsValid);

    }

    [Fact]
    public void SShip_CreateCommand_InvalidCode()
    {

        var shipCommand = new CreateShipCommand("Ship Name", 2, 2, "AAAA-1111-AA");
        var validation = _validator.Validate(shipCommand);
        var errors = ConvertErrors(validation);


        Assert.Equal("'Code' must follow the AAAA-1111-A1 format where A is any character from the Latin alphabet and 1 is a number from 0 to 9).", errors.First());
        Assert.False(validation.IsValid);

    }

    [Fact]
    public void Ship_CreateCommand_Valid()
    {

        var shipCommand = new CreateShipCommand("Ship Name", 2, 2, "AAAA-1111-A1");
        var validation = _validator.Validate(shipCommand);

        Assert.True(validation.IsValid);

    }

}