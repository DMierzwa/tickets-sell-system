using TicketsSellSystem.Application.Events.Commands.CreateEvent;
using TicketsSellSystem.Tests.TestUtils;

namespace TicketsSellSystem.Tests.Event.TestUtils;

public static class CreateEventCommandUtils
{
    public static CreateEventCommand CreateValidEventCommand()
    {
        string name = GeneratedUtils.RandomString(15);
        string description = GeneratedUtils.RandomString(40);

        return new CreateEventCommand(name, description);
    }

    internal static CreateEventCommand CreateEventCommandWithInvalidDescription(string description)
    {
        return CreateValidEventCommand() with { Description = description };
    }

    internal static CreateEventCommand CreateEventCommandWithInvalidName(string name)
    {
        return CreateValidEventCommand() with { Name = name };
    }
}