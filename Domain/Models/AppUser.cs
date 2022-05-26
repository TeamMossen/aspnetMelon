namespace Domain.Models;

/// <summary>
/// The user data and profile for our application
/// </summary>
public class AppUser : IdentityUser<int>
{
    public int ShoppingCartId { get; set; }

    public ShoppingCart ShoppingCart { get; set; } = default!;

}