namespace Domain.Models.Identity;

/// <summary>
/// The user data and profile for our application
/// </summary>
public class AppUser : IdentityUser<int>
{
    public int ShoppingCartId { get; set; }

    public ShoppingCart ShoppingCart { get; set; } = default!;

    public string ApiKey { get; set; } = default!;

}