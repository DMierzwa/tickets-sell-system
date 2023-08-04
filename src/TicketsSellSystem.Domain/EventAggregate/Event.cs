using TicketsSellSystem.Domain.Common.Models;
using TicketsSellSystem.Domain.Common.ValueObjects;
using TicketsSellSystem.Domain.EventAggregate.ValueObjects;

namespace TicketsSellSystem.Domain.EventAggregate;

public class Event : AggregateRoot<EventId>
{
    private Event(EventId eventId, EventName name)
        : base(eventId)
    {
        this.Name = name;
    }

    public EventName Name { get; private set; }

    public static Event Create(EventName name)
    {
        return
            new Event(
                EventId.CreateUnique(),
                name);
    }
}