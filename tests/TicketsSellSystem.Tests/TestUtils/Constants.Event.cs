namespace TicketsSellSystem.Tests.TestUtils;

public static partial class Constants
{
    public static class Event
    {
        public static string Name => GeneratedUtils.RandomString(10);

        public static string Description => GeneratedUtils.RandomString(60);
    }
}