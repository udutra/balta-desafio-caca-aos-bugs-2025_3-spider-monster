namespace BugStore.Api.Requests.Customers;

public class GetAllCustomersRequest(
    int pageNumber = Configuration.DefaultPageNumber,
    int pageSize = Configuration.DefaultPageSize)
    : PagedRequest(pageNumber, pageSize);