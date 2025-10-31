using BugStore.Api.Requests.Products;
using BugStore.Api.Responses.Products;

namespace BugStore.Api.Handlers.Interfaces;

public interface IHandlerProduct{
    Task<CreateProductResponse> CreateProductAsync(CreateProductRequest request,
        CancellationToken cancellationToken = default);
    Task<GetProductByIdResponse> GetProductByIdAsync(GetProductByIdRequest request,
        CancellationToken cancellationToken = default);
    Task<GetAllProductsResponse> GetAllProductsAsync(GetAllProductsRequest request,
        CancellationToken cancellationToken = default);
    Task<DeleteProductResponse> DeleteProductAsync(DeleteProductRequest request,
        CancellationToken cancellationToken = default);
    Task<UpdateProductResponse> UpdateProductAsync(UpdateProductRequest request,
        CancellationToken cancellationToken = default);

}