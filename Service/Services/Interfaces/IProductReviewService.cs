using Infrastructure.Models;

namespace Infrastructure.Services.Interfaces;

public interface IProductReviewService
{
    Task<ProductReviewsDto?> GetReviews(int productId);
}