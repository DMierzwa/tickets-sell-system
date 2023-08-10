using TicketsSellSystem.Application.Events.Commands.CreateEventSchedule;

namespace TicketsSellSystem.Tests.Event.TestUtils;

public class CreateEventScheduleCommandUtils
{
    public static CreateEventScheduleCommand Command()
    {
        Guid eventId = Guid.NewGuid();
        DateTime startDate = DateTime.Now.AddMinutes(5);
        bool isActive = true;

        return new(eventId, startDate, isActive);
    }
}