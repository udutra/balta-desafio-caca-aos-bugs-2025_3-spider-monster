using BugStore.Api.Models;

namespace BugStore.Api.Responses.Products;

public class GetProductByIdResponse(Product? data, int statusCode = Configuration.DefaultStatusCode,
    string message = "Produto encontrado com sucesso.") : Response<Product>(data, statusCode, message);