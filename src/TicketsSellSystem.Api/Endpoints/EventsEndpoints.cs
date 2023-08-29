namespace TicketsSellSystem.Api;

public class EventsEndpoints : IEndpoint
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder builder)
    {
        var builderGroup = builder.MapGroup("/events");

        builderGroup.MapGet("/", () => "GetEventEndpoint");

        return builderGroup;
    }
}