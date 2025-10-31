using BugStore.Api.Models;

namespace BugStore.Api.Responses.Orders;

public class CreateOrderResponse(Order? data, int statusCode = 201, string message = "Pedido criado com sucesso.")
    : Response<Order>(data, statusCode, message);