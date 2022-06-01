using System.Diagnostics;
using System.IO.Compression;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

namespace Service.Services;

public class AmazonService : IProductReviewService
{
    private readonly HttpClient _httpClient;
    private readonly AppDbContext _appDbContext;
    private readonly IConfiguration _configuration;

    public AmazonService(HttpClient httpClient, AppDbContext appDbContext, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _appDbContext = appDbContext;
        _configuration = configuration;
        Debug.WriteLine(_httpClient.BaseAddress);
    }


    public async Task<ProductReviewsDto?> GetReviews(int productId)
    {
        var productReview = await _appDbContext.ProductReviews.FindAsync(productId); //TODO temp
        if(productReview == null)
            return null;
        //IEnumerable<ReviewDto> result = new List<ReviewDto>();
        //var request = new HttpRequestMessage(HttpMethod.Get, productReview.ReviewUri);
        //var response = await _httpClient.SendAsync(request);
        ////var response = await _httpClient.GetAsync(productReview.ReviewUri);
        //if (response.IsSuccessStatusCode)
        //{
        //    using var contentStream = await response.Content.ReadAsStreamAsync();
        //    StreamReader reader = new StreamReader(contentStream);
        //    var test = reader.ReadToEnd();
        //    return new ReviewDto[0];
        //}

        //var response = await _httpClient.GetAsync(productReview.ReviewUri);
        //string responseBody = await response.Content.ReadAsStringAsync();

        //svar: responseJsonString="\u001f�\b\0\0\0\0\0\0\0��]k�0\u0018���+��&\u0012��dlt���fc��]���\r�Ȓ\\+8r�G�b�\u000f٭�F�tq@�{8�Dѻ\u..."

        //TODO Har fixat review dtos o jsonmapping så raden under ska funka om vi får in korrekt json data.

        return await _httpClient.GetFromJsonAsync<ProductReviewsDto>(_configuration["AmazonApiKey"] + productReview.ReviewUri);

    }

}

