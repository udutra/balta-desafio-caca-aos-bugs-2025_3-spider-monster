using BugStore.Api.Common.Api;
using BugStore.Api.Handlers.Interfaces;
using BugStore.Api.Requests.Products;
using BugStore.Api.Responses.Products;

namespace BugStore.Api.Endpoints.Products;

public class CreateProductEndPoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) => app.MapPost("", HandleAsync)
        .WithName("Product: Create")
        .WithSummary("Cria um novo produto")
        .WithDescription("Cria um novo produto")
        .WithOrder(1)
        .Produces<CreateProductResponse>();

    private static async Task<IResult> HandleAsync(IHandlerProduct handler, CreateProductRequest request,
        CancellationToken cancellationToken){

        var response = await handler.CreateProductAsync(request, cancellationToken);

        return response.IsSuccess
            ? TypedResults.Created($"/{response.Data?.Id}", response)
            : TypedResults.BadRequest(response.Data);
    }
}