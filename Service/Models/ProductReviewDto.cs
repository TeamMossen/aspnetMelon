﻿using System.Text.Json.Serialization;

namespace Service.Models;

public record ProductReviewsDto(bool Success, IEnumerable<ProductReviewDto> Review)
{
    [JsonPropertyName("success")]
    public bool Success { get; init; } = Success;
    //[JsonPropertyName("")]
    //public int Ratings { get; init; } = Ratings;
    [JsonPropertyName("reviews")]
    public IEnumerable<ProductReviewDto> Review { get; init; } = Review;
}

public record ProductReviewDto(
    [property: JsonPropertyName("review_title")] string Title,
    [property: JsonPropertyName("author_name")] string Author, 
    [property: JsonPropertyName("date")] string Date,
    [property: JsonPropertyName("rating")] int Rating, 
    [property: JsonPropertyName("review_text")] string Text,
    [property: JsonPropertyName("location")] string Location);