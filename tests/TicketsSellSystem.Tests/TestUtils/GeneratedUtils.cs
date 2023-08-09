namespace TicketsSellSystem.Tests.TestUtils;

public class GeneratedUtils
{
    private static readonly Random _random = new();

    public static string RandomString(int length = 3)
    {
        const string @base = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        char[] chars =
            Enumerable.Repeat(@base, length)
                .Select(x => x[_random.Next(x.Length)])
                .ToArray();

        return new string(chars);
    }
}