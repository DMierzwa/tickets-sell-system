using TicketsSellSystem.Domain.Common.Models;
using TicketsSellSystem.Domain.EventScheduleAggregate.ValueObjects;

namespace TicketsSellSystem.Domain.EventScheduleAggregate.Entities;

public sealed class EventScheduleItem : Entity<EventScheduleItemId>
{
    private EventScheduleItem(
        EventScheduleItemId id,
        DateTime startDate,
        string name,
        bool isActive)
        : base(id)
    {
        this.StartDate = startDate;
        this.Name = name;
        this.IsActive = isActive;
    }

    public DateTime StartDate { get; private set; }

    public bool IsActive { get; private set; }

    public string Name { get; private set; }

    public static EventScheduleItem Create(DateTime startDate, string name, bool isActive)
    {
        return new EventScheduleItem(
            EventScheduleItemId.CreateUnique(),
            startDate,
            name,
            isActive);
    }
}