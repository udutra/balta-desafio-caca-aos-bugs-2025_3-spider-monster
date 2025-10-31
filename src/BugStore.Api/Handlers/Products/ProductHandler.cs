using BugStore.Api.Data;
using BugStore.Api.Handlers.Interfaces;
using BugStore.Api.Models;
using BugStore.Api.Requests.Products;
using BugStore.Api.Responses.Products;
using Microsoft.EntityFrameworkCore;

namespace BugStore.Api.Handlers.Products;

public class ProductHandler(AppDbContext context) : IHandlerProduct{

    public async Task<CreateProductResponse> CreateProductAsync(CreateProductRequest request,
        CancellationToken cancellationToken = default){

        try{
            var product = new Product(request.Title, request.Description, request.Slug, request.Price);
            await context.Products.AddAsync(product, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            return new CreateProductResponse(product);
        }
        catch (DbUpdateException){
            return new CreateProductResponse(null, 500, "Erro ao criar o produto. ErroCod: PH0001");
        }
        catch (OperationCanceledException){
            return new CreateProductResponse(null, 499, "Operação cancelada.");
        }
        catch (Exception){
            return new CreateProductResponse(null, 500, "Erro inesperado. ErroCod: PH0001-GEN");
        }
    }

    public async Task<GetProductByIdResponse> GetProductByIdAsync(GetProductByIdRequest request,
        CancellationToken cancellationToken = default){
        try{
            var product = await context.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

            return product is null
                ? new GetProductByIdResponse(null, 404, "Produto não encontrado.")
                : new GetProductByIdResponse(product);
        }
        catch (OperationCanceledException){
            return new GetProductByIdResponse(null, 499, "Operação cancelada.");
        }
        catch{
            return new GetProductByIdResponse(null, 500, "Erro ao buscar o produto. ErroCod: PH0002");
        }
    }

    public async Task<GetAllProductsResponse> GetAllProductsAsync(GetAllProductsRequest request,
        CancellationToken cancellationToken = default){

        try{
            var products = await context.Products
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return new GetAllProductsResponse(products);
        }
        catch (OperationCanceledException){
            return new GetAllProductsResponse([], 499, "Operação cancelada.");
        }
        catch{
            return new GetAllProductsResponse([], 500,
                "Erro ao listar os produtos. ErroCod: PH0003");
        }
    }

    public async Task<DeleteProductResponse> DeleteProductAsync(DeleteProductRequest request,
        CancellationToken cancellationToken = default){
        try
        {
            var product = await context.Products
                .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

            if (product is null)
                return new DeleteProductResponse(null, 404, "Produto não encontrado.");

            context.Products.Remove(product);
            await context.SaveChangesAsync(cancellationToken);

            return new DeleteProductResponse(null);
        }
        catch (DbUpdateException){
            return new DeleteProductResponse(null, 500,
                "Erro ao excluir o produto. ErroCod: PH0004");
        }
        catch (OperationCanceledException){
            return new DeleteProductResponse(null, 499, "Operação cancelada.");
        }
        catch
        {
            return new DeleteProductResponse(null, 500,
                "Erro inesperado. ErroCod: PH0004-GEN");
        }
    }

    public async Task<UpdateProductResponse> UpdateProductAsync(UpdateProductRequest request,
        CancellationToken cancellationToken = default){
        try
        {
            var product = await context.Products
                .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

            if (product is null)
                return new UpdateProductResponse(null, 404, "Produto não encontrado.");

            product.Update(request.Title, request.Description, request.Slug, request.Price);

            context.Products.Update(product);
            await context.SaveChangesAsync(cancellationToken);

            return new UpdateProductResponse(product);
        }
        catch (DbUpdateException)
        {
            return new UpdateProductResponse(null, 500,
                "Erro ao atualizar o produto. ErroCod: PH0005");
        }
        catch (OperationCanceledException)
        {
            return new UpdateProductResponse(null, 499,
                "Operação cancelada.");
        }
        catch
        {
            return new UpdateProductResponse(null, 500,
                "Erro inesperado. ErroCod: PH0005-GEN");
        }
    }
}