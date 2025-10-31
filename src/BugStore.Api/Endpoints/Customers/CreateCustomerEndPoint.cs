using BugStore.Api.Common.Api;
using BugStore.Api.Handlers.Interfaces;
using BugStore.Api.Requests.Customers;
using BugStore.Api.Responses.Customers;

namespace BugStore.Api.Endpoints.Customers;

public class CreateCustomerEndPoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) => app.MapPost("", HandleAsync)
        .WithName("Customer: Create")
        .WithSummary("Cria um novo cliente")
        .WithDescription("Cria um novo cliente")
        .WithOrder(1)
        .Produces<CreateCustomerResponse>();

    private static async Task<IResult> HandleAsync(IHandlerCustomer handler, CreateCustomerRequest request,
        CancellationToken cancellationToken){

        var response = await handler.CreateCustomerAsync(request, cancellationToken);

        return response.IsSuccess
            ? TypedResults.Created($"/{response.Data?.Id}", response)
            : TypedResults.BadRequest(response.Data);
    }
}