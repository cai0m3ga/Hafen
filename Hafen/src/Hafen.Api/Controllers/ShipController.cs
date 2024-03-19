using ErrorOr;
using Hafen.Application.ShipApp.Commands.Create;
using Hafen.Application.ShipApp.Commands.Delete;
using Hafen.Application.ShipApp.Commands.Update;
using Hafen.Application.ShipApp.Queries.Get;
using Hafen.Application.ShipApp.Queries.List;
using Hafen.Contracts.ShipContracts.Create;
using Hafen.Contracts.ShipContracts.Get;
using Hafen.Contracts.ShipContracts.List;
using Hafen.Domain.Entities;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace Hafen.Api.Controllers;

[Route("[controller]")]
public class ShipController : ApiController
{

    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public ShipController(ISender mediator, IMapper mapper)
    {

        _mediator = mediator;
        _mapper = mapper;

    }

    [HttpGet]
    public async Task<IActionResult> List()
    {

        ErrorOr<List<Ship>> result = await _mediator.Send(new ListShipCommand());

        return result.Match(

            result => Ok(new ListShipResponse(Ships: _mapper.Map<List<ListShipItem>>(result))),
            errors => Problem(errors)

        );

    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {

        var command = new GetShipCommand(Id: id);
        ErrorOr<Ship> result = await _mediator.Send(command);

        return result.Match(

            result => Ok(_mapper.Map<GetShipReponse>(result)),
            errors => Problem(errors)

        );

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {

        var command = new DeleteShipCommand(Id: id);
        ErrorOr<bool> result = await _mediator.Send(command);

        return result.Match(

            result => Ok(),
            errors => Problem(errors)

        );

    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateShipRequest request)
    {

        var command = _mapper.Map<CreateShipCommand>(request);
        ErrorOr<Ship> result = await _mediator.Send(command);

        return result.Match(

            result => Ok(_mapper.Map<CreateShipResponse>(result)),
            errors => Problem(errors)

        );

    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateShipRequest request)
    {

        var command = _mapper.Map<UpdateShipCommand>(request);
        ErrorOr<Ship> result = await _mediator.Send(command);

        return result.Match(

            result => Ok(_mapper.Map<UpdateShipReponse>(result)),
            errors => Problem(errors)

        );

    }

}