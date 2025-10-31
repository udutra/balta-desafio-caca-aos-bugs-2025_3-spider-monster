using BugStore.Api.Common.Api;
using BugStore.Api.Handlers.Interfaces;
using BugStore.Api.Requests.Products;
using BugStore.Api.Responses.Products;

namespace BugStore.Api.Endpoints.Products;

public class GetProductByIdEndPoint : IEndpoint{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("{id:guid}", HandleAsync)
            .WithName("Product: Get by Id")
            .WithSummary("Busca o produto pelo Id")
            .WithDescription("Busca o produto pelo Id")
            .WithOrder(2)
            .Produces<GetProductByIdResponse>();

    private static async Task<IResult> HandleAsync(IHandlerProduct handler, Guid id){
        if (string.IsNullOrEmpty(id.ToString())){
            TypedResults.BadRequest(new UpdateProductResponse(null, 500, "Id do produto é obrigatório"));
        }

        var request = new GetProductByIdRequest(id);

        var result = await handler.GetProductByIdAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}