using TicketsSellSystem.Application.Events.Commands.CreateEvent;
using TicketsSellSystem.Tests.TestUtils;

namespace TicketsSellSystem.Tests.Event.TestUtils;

public static class CreateEventCommandUtils
{
    public static CreateEventCommand CreateEventCommand()
    {
        string name = Constants.Event.Name;
        string description = Constants.Event.Description;

        return new CreateEventCommand(name, description);
    }

    public static CreateEventCommand CreateEventCommandWithoutName()
    {
        return CreateEventCommand() with { Name = string.Empty };
    }
}