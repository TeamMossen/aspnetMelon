namespace Infrastructure;

public static class KeyGenerator
{
    public static string Generate(int length = 16)
    {
        Random random = new Random();
        const string chars = "abcdefghijklmnopqvstuvwzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }
}