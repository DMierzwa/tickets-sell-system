using TicketsSellSystem.Domain.Common.Models;
using TicketsSellSystem.Domain.Common.ValueObjects;
using TicketsSellSystem.Domain.EventAggregate.ValueObjects;

namespace TicketsSellSystem.Domain.EventAggregate;

public class Event : AggregateRoot<EventId>
{
    private Event(
        EventId eventId,
        EventName name,
        EventDescription description)
        : base(eventId)
    {
        this.Name = name;
        this.Description = description;
    }

    public EventName Name { get; private set; }

    public EventDescription Description { get; private set; }

    public static Event Create(
        EventName name,
        EventDescription description)
    {
        return
            new Event(
                EventId.CreateUnique(),
                name,
                description);
    }
}