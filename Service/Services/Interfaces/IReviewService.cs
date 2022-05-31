namespace Service.Services.Interfaces;

public interface IReviewService
{
    Task<IEnumerable<ReviewDto>?> GetReviews(int productId);
}