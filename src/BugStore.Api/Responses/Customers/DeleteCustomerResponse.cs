using BugStore.Api.Models;

namespace BugStore.Api.Responses.Customers;

public class DeleteCustomerResponse(Customer? data = null, int statusCode = Configuration.DefaultStatusCode,
    string? message = "Cliente removido com sucesso.")
    : Response<Customer>(data, statusCode, message);