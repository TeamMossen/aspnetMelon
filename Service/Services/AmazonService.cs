using System.Diagnostics;
using System.Net.Http.Json;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Services;

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
        
        var productReview = await _appDbContext.ProductReviews.FindAsync(productId); 
        
        if(productReview == null)
            return null;

        return await _httpClient.GetFromJsonAsync<ProductReviewsDto>(_configuration["AmazonApiKey"] + productReview.ReviewUri);

    }

}

