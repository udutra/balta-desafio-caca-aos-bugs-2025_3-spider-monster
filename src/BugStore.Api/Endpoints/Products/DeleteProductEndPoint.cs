using BugStore.Api.Common.Api;
using BugStore.Api.Handlers.Interfaces;
using BugStore.Api.Requests.Products;
using BugStore.Api.Responses.Products;

namespace BugStore.Api.Endpoints.Products;

public class DeleteProductEndPoint : IEndpoint{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapDelete("/{id:guid}", HandleAsync)
            .WithName("Products: Delete")
            .WithSummary("Exclui um produto")
            .WithDescription("Exclui um produto")
            .WithOrder(5)
            .Produces<DeleteProductResponse>();

    private static async Task<IResult> HandleAsync(IHandlerProduct handler, Guid id){
        if (string.IsNullOrEmpty(id.ToString())){
            TypedResults.BadRequest(new UpdateProductResponse(null, 500, "Id do produto é obrigatório"));
        }

        var request = new DeleteProductRequest(id);

        var result = await handler.DeleteProductAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}