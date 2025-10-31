namespace BugStore.Api.Requests.Customers;

public class DeleteCustomerRequest(Guid id){
    public Guid Id { get; set; } = id;
}