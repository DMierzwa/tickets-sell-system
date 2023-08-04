using TicketsSellSystem.Domain.Common.Models;
using TicketsSellSystem.Domain.Common.ValueObjects;
using TicketsSellSystem.Domain.EventScheduleAggregate.ValueObjects;

namespace TicketsSellSystem.Domain.EventScheduleAggregate.Entities;

public sealed class EventScheduleItem : Entity<EventScheduleItemId>
{
    private EventScheduleItem(
        EventScheduleItemId id,
        DateTime startDate,
        EventId eventId,
        bool isActive)
        : base(id)
    {
        this.StartDate = startDate;
        this.EventId = eventId;
        this.IsActive = isActive;
    }

    public DateTime StartDate { get; private set; }

    public bool IsActive { get; private set; }

    public EventId EventId { get; private set; }

    public static EventScheduleItem Create(DateTime startDate, EventId eventId, bool isActive)
    {
        return new EventScheduleItem(
            EventScheduleItemId.CreateUnique(),
            startDate,
            eventId,
            isActive);
    }
}