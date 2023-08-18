using TicketsSellSystem.Domain.Common.Models;
using TicketsSellSystem.Domain.EventAggregate.ValueObjects;

namespace TicketsSellSystem.Domain.EventAggregate.Entities;

public sealed class EventSchedule : Entity<EventScheduleId>
{
    private EventSchedule(
        EventScheduleId id,
        EventId eventId,
        DateTime startDate,
        bool isActive)
        : base(id)
    {
        this.EventId = eventId;
        this.StartDate = startDate;
        this.IsActive = isActive;
    }

    public DateTime StartDate { get; private set; }

    public bool IsActive { get; private set; }

    public EventId EventId { get; private set; }

    public static EventSchedule Create(
        EventId eventId,
        DateTime startDate,
        bool isActive)
    {
        return new EventSchedule(
            EventScheduleId.CreateUnique(),
            eventId,
            startDate,
            isActive);
    }
}