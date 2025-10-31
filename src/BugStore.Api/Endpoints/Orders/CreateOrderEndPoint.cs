using BugStore.Api.Common.Api;
using BugStore.Api.Handlers.Interfaces;
using BugStore.Api.Requests.Orders;
using BugStore.Api.Responses.Orders;

namespace BugStore.Api.Endpoints.Orders;

public class CreateOrderEndPoint : IEndpoint{
    public static void Map(IEndpointRouteBuilder app) => app.MapPost("", HandleAsync)
        .WithName("Order: Create")
        .WithSummary("Cria um novo pedido")
        .WithDescription("Cria um novo pedido")
        .WithOrder(1)
        .Produces<CreateOrderResponse>();

    private static async Task<IResult> HandleAsync(IHandlerOrder handler, CreateOrderRequest request,
        CancellationToken cancellationToken){

        var response = await handler.CreateOrderAsync(request, cancellationToken);

        return response.IsSuccess
            ? TypedResults.Created($"/{response.Data?.Id}", response)
            : TypedResults.BadRequest(response.Data);
    }
}