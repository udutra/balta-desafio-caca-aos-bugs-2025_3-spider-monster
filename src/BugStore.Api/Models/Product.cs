namespace BugStore.Api.Models;

public class Product(string title, string description, string slug, decimal price){
    public Guid Id { get; set; } = Guid.CreateVersion7();
    public string Title { get; set; } = title;

    public string Description { get; set; } = description;
    public string Slug { get; set; } = slug;
    public decimal Price { get; set; } = price;



    public void Update(string? title, string? description, string? slug, decimal? price){
        if (!string.IsNullOrWhiteSpace(title)){
            Title = title;
        }

        if (!string.IsNullOrWhiteSpace(description)){
            Description = description;
        }

        if (!string.IsNullOrWhiteSpace(slug)){
            Slug = slug;
        }

        if (price != null){
            Price = price.Value;
        }
    }

}