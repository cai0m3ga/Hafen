
<img src="https://i.ibb.co/L8gLNCB/pixlr-image-generator-54319689-06fc-4256-aa87-90ecce08087b.png" width="400" />

# Hafen

This application was created with the solo purpose of fulfilling the proposed code challenge.

## Architecture

REST API following Clean Architecture & DDD using .NET 6

## Remarkable Libs

 - **ErrorOr**: Used to better control the application flow and avoid the usage of exceptions for most cases;

- **FluentValidaton**: This lib contain most of the needed validations and played a major role with Mediatr using pipeline behaviors to validate Commands and Queries;

- **Mediatr**: Responsible for handling all Commands and Queries including validations.

### Executing program

This application requires [**.NET 6 SDK**](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) in order to run

To run the project from the root:
```
 dotnet run --project .\src\Hafen.Api\
```
To run tests:
```
 dotnet test
```
This application contains Swagger and with the project running can be found under:
```
 https://localhost:7173/swagger/index.html
```
Remembering that your application may start in another port.
