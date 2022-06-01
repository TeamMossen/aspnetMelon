namespace Service.Services.Interfaces;

public interface IProductReviewService
{
    Task<ProductReviewsDto?> GetReviews(int productId);
}