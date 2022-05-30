namespace Domain.Models;

public class Category
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = default!;
    public string CategoryDescription { get; set; } = default!;
    public virtual ICollection<Product>? Products { get; set; }
}