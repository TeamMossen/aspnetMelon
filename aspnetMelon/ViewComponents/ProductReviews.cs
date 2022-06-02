using Microsoft.AspNetCore.Mvc;

namespace aspnetMelon.ViewComponents
{
    public class ProductReviews : ViewComponent
    {
        private readonly IProductReviewService _reviewService;


        public ProductReviews(IProductReviewService reviewService)
        {
            _reviewService = reviewService;
        }
        public async Task<IViewComponentResult> InvokeAsync(int productId)
        {
            var res = await _reviewService.GetReviews(productId);
            return View(res);
        }
    }
}
