using System.Diagnostics;
using System.Net.Http.Json;

namespace Service.Services;

public class AmazonService : IReviewService
{
    private readonly HttpClient _httpClient;
    private readonly AppDbContext _appDbContext;

    public AmazonService(HttpClient httpClient, AppDbContext appDbContext)
    {
        _httpClient = httpClient;
        _appDbContext = appDbContext;
        Debug.WriteLine(_httpClient.BaseAddress);
    }


    public async Task<IEnumerable<ReviewDto>?> GetReviews(int productId)
    {
        var productReview = await _appDbContext.ProductReviews.FindAsync(5); //TODO temp
        if(productReview == null)
            return null;

        //var responseInfo = await _httpClient.GetAsync(productReview.ReviewUri);

        var responseJsonString = await _httpClient.GetStringAsync(productReview.ReviewUri);
        //svar: responseJsonString="\u001f�\b\0\0\0\0\0\0\0��]k�0\u0018���+��&\u0012��dlt���fc��]���\r�Ȓ\\+8r�G�b�\u000f٭�F�tq@�{8�Dѻ\u..."

        //TODO Har fixat review dtos o jsonmapping så raden under ska funka om vi får in korrekt json data.
        //var p = await _httpClient.GetFromJsonAsync<ReviewDto>(productReview.ReviewUri);


        return new ReviewDto[1];
    }
}

