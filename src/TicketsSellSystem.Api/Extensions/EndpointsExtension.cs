namespace TicketsSellSystem.Api;

public static class EndpointsExtension
{
    public static WebApplication MapEndpoints(this WebApplication app)
    {
        var modules = DiscoverModules();

        foreach (var module in modules)
        {
            module.MapEndpoints(app);
        }
        return app;
    }

    private static IEnumerable<IEndpoint> DiscoverModules()
    {
        return typeof(IEndpoint).Assembly
            .GetTypes()
            .Where(x => x.IsClass && x.IsAssignableTo(typeof(IEndpoint)))
            .Select(Activator.CreateInstance)
            .Cast<IEndpoint>();
    }
}

public interface IEndpoint
{
    IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder builder);
}