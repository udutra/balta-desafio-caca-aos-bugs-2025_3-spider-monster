namespace BugStore.Api.Requests.Products;

public class GetProductByIdRequest(Guid id){
    public Guid Id { get; set; } = id;
}