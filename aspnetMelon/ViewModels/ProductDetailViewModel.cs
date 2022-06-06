using Infrastructure.Models.Dtos;

namespace aspnetMelon.ViewModels;

public class ProductDetailViewModel
{
    public ProductDto Product { get; set; }
    public ProductReviewsDto ProductReviews { get; set; }
}