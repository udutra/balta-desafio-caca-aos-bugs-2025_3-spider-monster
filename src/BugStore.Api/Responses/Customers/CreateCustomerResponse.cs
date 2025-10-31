using BugStore.Api.Models;

namespace BugStore.Api.Responses.Customers;

public class CreateCustomerResponse(Customer? data, int statusCode = Configuration.DefaultStatusCode,
    string message = "Cliente criado com sucesso.") : Response<Customer>(data, statusCode, message);