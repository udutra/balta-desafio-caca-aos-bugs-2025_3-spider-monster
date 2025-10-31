using BugStore.Api.Requests.Customers;
using BugStore.Api.Responses.Customers;

namespace BugStore.Api.Handlers.Interfaces;

public interface IHandlerCustomer{
    Task<CreateCustomerResponse> CreateCustomerAsync(CreateCustomerRequest request, CancellationToken cancellationToken = default);
    Task<GetCustomerByIdResponse> GetCustomerByIdAsync(GetCustomerByIdRequest request, CancellationToken cancellationToken = default);
    Task<GetAllCustomersResponse> GetAllCustomersAsync(GetAllCustomersRequest request, CancellationToken cancellationToken = default);
    Task<UpdateCustomerResponse> UpdateCustomerAsync(UpdateCustomerRequest request, CancellationToken cancellationToken = default);
    Task<DeleteCustomerResponse> DeleteCustomerAsync(DeleteCustomerRequest request, CancellationToken cancellationToken = default);
}