using TicketsSellSystem.Domain.Common.Models;

namespace TicketsSellSystem.Domain.EventScheduleAggregate.ValueObjects;

public sealed class EventScheduleItemId : ValueObject
{
    private EventScheduleItemId(Guid value)
    {
        this.Value = value;
    }

    public Guid Value { get; private set; }

    public static EventScheduleItemId CreateUnique()
    {
        return new EventScheduleItemId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return this.Value;
    }
}