using Hafen.Domain.Entities;

namespace Hafen.Domain.UnitTests.Entities;

public class ShipTest
{

    [Fact]
    public void Ship_Create_InvalidName()
    {

        var ship = new Ship(Guid.NewGuid(), "", 2, 2, "AAAA-1111-A1");
        Assert.Equal("'Name' must not be empty.", ship.ValidationErrors().First());
        Assert.False(ship.Valid());

    }

    [Fact]
    public void Ship_Create_InvalidLength()
    {

        var ship = new Ship(Guid.NewGuid(), "Ship Name", 0, 2, "AAAA-1111-A1");
        Assert.Equal("'Length' must be greater than '0'.", ship.ValidationErrors().First());
        Assert.False(ship.Valid());

    }

    [Fact]
    public void Ship_Create_InvalidWidth()
    {

        var ship = new Ship(Guid.NewGuid(), "Ship Name", 2, 0, "AAAA-1111-A1");
        Assert.Equal("'Width' must be greater than '0'.", ship.ValidationErrors().First());
        Assert.False(ship.Valid());

    }

    [Fact]
    public void Ship_Create_EmptyCode()
    {

        var ship = new Ship(Guid.NewGuid(), "Ship Name", 2, 2, "");
        Assert.Equal("'Code' must not be empty.", ship.ValidationErrors().First());
        Assert.False(ship.Valid());

    }

    [Fact]
    public void Ship_Create_InvalidCode()
    {

        var ship = new Ship(Guid.NewGuid(), "Ship Name", 2, 2, "AAAA-1111-AA");
        Assert.Equal("'Code' must follow the AAAA-1111-A1 format where A is any character from the Latin alphabet and 1 is a number from 0 to 9).", ship.ValidationErrors().First());
        Assert.False(ship.Valid());

    }

    [Fact]
    public void Ship_Create_ValidGuid()
    {

        var guid = Guid.NewGuid();
        var ship = new Ship(guid, "Ship Name", 2, 2, "AAAA-1111-A1");
        Assert.Equal(guid, ship.Id);
        Assert.True(ship.Valid());

    }

    [Fact]
    public void Ship_Create_Valid()
    {

        var ship = new Ship(Guid.NewGuid(), "Ship Name", 2, 2, "AAAA-1111-A1");
        Assert.True(ship.Valid());

    }

}