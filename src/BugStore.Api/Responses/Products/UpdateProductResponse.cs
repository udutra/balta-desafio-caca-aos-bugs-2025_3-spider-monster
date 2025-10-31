using BugStore.Api.Models;

namespace BugStore.Api.Responses.Products;

public class UpdateProductResponse(Product? data, int statusCode = Configuration.DefaultStatusCode,
    string message = "Produto atualizado com sucesso.") : Response<Product>(data, statusCode, message);