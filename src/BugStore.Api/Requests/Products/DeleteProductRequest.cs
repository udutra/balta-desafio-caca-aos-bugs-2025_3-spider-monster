namespace BugStore.Api.Requests.Products;

public class DeleteProductRequest(Guid id){
    public Guid Id { get; set; } = id;
}