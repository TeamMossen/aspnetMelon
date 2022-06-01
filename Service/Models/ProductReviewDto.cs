using System.Text.Json.Serialization;

namespace Service.Models;

public record ProductReviewsDto(
    [property: JsonPropertyName("success")] bool Success,
    [property: JsonPropertyName("reviews")] IEnumerable<ProductReviewDto> Reviews)
{
}

public record ProductReviewDto(
    [property: JsonPropertyName("review_title")] string Title,
    [property: JsonPropertyName("author_name")] string Author, 
    [property: JsonPropertyName("date")] string Date,
    [property: JsonPropertyName("rating")] int Rating, 
    [property: JsonPropertyName("review_text")] string Text,
    [property: JsonPropertyName("location")] string Location);