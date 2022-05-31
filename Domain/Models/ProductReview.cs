namespace Domain.Models;

public class ProductReview
{
    public int ProductId { get; set; }

    public Product Product { get; set; }

    public string ReviewUri { get; set; } = default!;
}