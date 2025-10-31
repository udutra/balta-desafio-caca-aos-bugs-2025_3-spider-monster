namespace BugStore.Api.Requests.Products;

public class UpdateProductRequest(Guid id, string? title, string? description, string? slug, decimal? price){
    public Guid Id { get; set; } = id;
    public string? Title { get; set; } = title;
    public string? Description { get; set; } = description;
    public string? Slug { get; set; } = slug;
    public decimal? Price { get; set; } = price;
}