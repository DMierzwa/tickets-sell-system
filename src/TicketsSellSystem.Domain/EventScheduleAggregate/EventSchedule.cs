using TicketsSellSystem.Domain.Common.Models;
using TicketsSellSystem.Domain.EventScheduleAggregate.Entities;
using TicketsSellSystem.Domain.EventScheduleAggregate.ValueObjects;

namespace TicketsSellSystem.Domain.EventScheduleAggregate;

public sealed class EventSchedule : AggregateRoot<EventScheduleId>
{
    private readonly List<EventScheduleItem> _events = new();

    private EventSchedule(EventScheduleId id)
        : base(id)
    {
    }

    public IReadOnlyList<EventScheduleItem> Items => this._events.ToList();

    public static EventSchedule Create()
    {
        return new EventSchedule(
            EventScheduleId.CreateUnique());
    }

    public void AddEventScheduleItem(EventScheduleItem item)
    {
        this._events.Add(item);
    }
}