using System.Text.RegularExpressions;
using FluentValidation;
using Hafen.Domain.Entities;

namespace Hafen.Domain.Validators;

public class ShipValidator : AbstractValidator<Ship>
{

    public ShipValidator()
    {

        RuleFor(e => e.Id).NotEmpty();
        RuleFor(e => e.Name).NotEmpty();
        RuleFor(e => e.Length).GreaterThan(0);
        RuleFor(e => e.Width).GreaterThan(0);
        RuleFor(e => e.Code)
            .NotEmpty()
            .Matches(@"^[A-Z]{4}-[0-9]{4}-[A-Z]{1}[0-9]{1}$", RegexOptions.IgnoreCase)
            .WithMessage("'Code' must follow the AAAA-1111-A1 format where A is any character from the Latin alphabet and 1 is a number from 0 to 9).");

    }

}