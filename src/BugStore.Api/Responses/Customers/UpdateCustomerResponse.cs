using BugStore.Api.Models;

namespace BugStore.Api.Responses.Customers;

public class UpdateCustomerResponse(Customer? data, int statusCode = Configuration.DefaultStatusCode,
    string message = "Cliente atualizado com sucesso.")
    : Response<Customer>(data, statusCode, message);