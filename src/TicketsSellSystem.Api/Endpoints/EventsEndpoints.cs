using Microsoft.AspNetCore.Http.HttpResults;
using TicketsSellSystem.Application.Events.Commands.CreateEvent;

namespace TicketsSellSystem.Api;

public class EventsEndpoints : IEndpoint
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder builder)
    {
        var builderGroup = builder.MapGroup("/events");

        builderGroup.MapGet("/", this.GetResult);
        builderGroup.MapPost("/", this.CreateEvent);

        return builderGroup;
    }

    private IResult GetResult()
    {
        return TypedResults.Ok("GetResult");
    }

    private async Task<IResult> CreateEvent()
    {
        string name = "CreateEvent name";
        string description = "CreateEvent description";

        CreateEventCommand command = new(name, description);
        var commandHandler = new CreateEventCommandHandler();

        var result = await commandHandler.Handle(command, CancellationToken.None);

        return TypedResults.Ok(result);
    }
}