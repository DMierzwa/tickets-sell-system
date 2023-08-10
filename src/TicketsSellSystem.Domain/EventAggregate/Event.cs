using TicketsSellSystem.Domain.Common.Models;
using TicketsSellSystem.Domain.Common.ValueObjects;
using TicketsSellSystem.Domain.EventAggregate.Entities;
using TicketsSellSystem.Domain.EventAggregate.ValueObjects;

namespace TicketsSellSystem.Domain.EventAggregate;

public class Event : AggregateRoot<EventId>
{
    private readonly List<EventSchedule> _eventSchedules = new();

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

    public IReadOnlyList<EventSchedule> EventSchedules => this._eventSchedules.ToList();

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

    public void AddEventSchedule(EventSchedule eventSchedule)
    {
        this._eventSchedules.Add(eventSchedule);
    }
}