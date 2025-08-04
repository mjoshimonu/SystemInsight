using SystemInsight.API.Endpoints;

namespace SystemInsight.API.Extensions;

public static class EndpointExtensions
{
    public static void RegisterAllEndpoints(this WebApplication app)
    {
        var endpointDefs = typeof(Program).Assembly
            .GetTypes()
            .Where(t => t is { IsClass: true, IsAbstract: false } &&
                        typeof(IEndpointDefinition).IsAssignableFrom(t))
            .Select(Activator.CreateInstance)
            .Cast<IEndpointDefinition>();

        foreach (var endpointDef in endpointDefs)
        {
            endpointDef.RegisterEndpoints(app);
        }
    }
}
