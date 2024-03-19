using ErrorOr;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Hafen.Api.Controllers;

[ApiController]
[AllowAnonymous]
public abstract class ApiController : ControllerBase
{

    protected IActionResult Problem(List<Error> errors)
    {

        if (errors.Count is 0)
            return Problem();

        if (errors.Any(error => error.Type == ErrorType.Unexpected))
            return Problem(
                statusCode: StatusCodes.Status500InternalServerError,
                title: "An unexpectected error ocurred during your request");

        if (errors.All(error => error.Type == ErrorType.Validation))
        {

            var modelStateDictionary = new ModelStateDictionary();

            foreach (var error in errors)
            {

                modelStateDictionary.AddModelError(
                    error.Code,
                    error.Description);

            }

            return ValidationProblem(modelStateDictionary);

        }

        var firstError = errors[0];
        var statusCode = firstError.Type switch
        {

            ErrorType.Conflict => StatusCodes.Status409Conflict,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            _ => StatusCodes.Status500InternalServerError

        };

        return Problem(statusCode: statusCode, title: firstError.Description);

    }

}