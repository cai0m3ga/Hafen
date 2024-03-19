using System.Text.RegularExpressions;
using FluentValidation;

namespace Hafen.Application.ShipApp.Commands.Create;

public class CreateShipCommandValidator : AbstractValidator<CreateShipCommand>
{

    public CreateShipCommandValidator()
    {

        RuleFor(e => e.Name).NotEmpty();
        RuleFor(e => e.Code).NotEmpty();
        RuleFor(e => e.Length).GreaterThan(0);
        RuleFor(e => e.Width).GreaterThan(0);
        RuleFor(e => e.Code).Matches(@"^[A-Z]{4}-[0-9]{4}-[A-Z]{1}[0-9]{1}$", RegexOptions.IgnoreCase)
            .WithMessage("'Code' must follow the AAAA-1111-A1 format where A is any character from the Latin alphabet and 1 is a number from 0 to 9).");

    }

}