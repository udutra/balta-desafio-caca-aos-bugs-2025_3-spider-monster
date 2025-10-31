namespace BugStore.Api.Models;

public class OrderLine(Guid orderId, int quantity, decimal total, Guid productId){
    public Guid Id { get; set; } = Guid.CreateVersion7();
    public Guid OrderId { get; set; } = orderId;
    public int Quantity { get; set; } = quantity;
    public decimal Total { get; set; } = total;
    public Guid ProductId { get; set; } = productId;
    public Product? Product { get; set; }
    public Order? Order { get; set; }
}