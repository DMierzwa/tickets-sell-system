using TicketsSellSystem.Domain.Common.Models;

namespace TicketsSellSystem.Domain.EventAggregate.ValueObjects;

public sealed class EventScheduleId : ValueObject
{
    private EventScheduleId(Guid value)
    {
        this.Value = value;
    }

    public Guid Value { get; private set; }

    public static EventScheduleId CreateUnique()
    {
        return new EventScheduleId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return this.Value;
    }
}