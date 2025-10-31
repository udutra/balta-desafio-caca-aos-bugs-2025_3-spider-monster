using BugStore.Api.Models;

namespace BugStore.Api.Responses.Products;

public class CreateProductResponse(Product? data, int statusCode = 201, string message = "Produto criado com sucesso.")
    : Response<Product>(data, statusCode, message);