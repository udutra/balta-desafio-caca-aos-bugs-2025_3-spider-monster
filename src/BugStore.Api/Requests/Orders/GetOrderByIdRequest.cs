namespace BugStore.Api.Requests.Orders;

public class GetOrderByIdRequest(Guid id){
    public Guid Id { get; set; } = id;
}