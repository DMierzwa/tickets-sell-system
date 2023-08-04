using TicketsSellSystem.Domain.Common.Models;

namespace TicketsSellSystem.Domain.Common.ValueObjects;

public class EventId : ValueObject
{
    private EventId(Guid value)
    {
        this.Value = value;
    }

    public Guid Value { get; private set; }

    public static EventId CreateUnique()
    {
        return new EventId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return this.Value;
    }
}