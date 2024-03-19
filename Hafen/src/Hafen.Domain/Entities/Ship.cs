using FluentValidation.Results;
using Hafen.Domain.Entities.Common;
using Hafen.Domain.Validators;

namespace Hafen.Domain.Entities;

public class Ship : IEntity
{

    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Name { get; private set; } = null!;
    public float Length { get; private set; }
    public float Width { get; private set; }
    public string Code { get; private set; } = null!;

    public Ship(Guid id, string name, float length, float width, string code)
    {

        Id = id;
        Name = name;
        Length = length;
        Width = width;
        Code = code;

    }

    public void Update(string name, float length, float width, string code)
    {

        Name = name;
        Length = length;
        Width = width;
        Code = code;

    }

    public bool Valid()
    {

        return new ShipValidator().Validate(this).IsValid;

    }

    public List<string> ValidationErrors()
    {

        return new ShipValidator()
            .Validate(this)
            .Errors
            .Select(e => e.ErrorMessage)
            .ToList();

    }

}