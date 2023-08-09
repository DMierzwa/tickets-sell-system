using TicketsSellSystem.Domain.Common.Models;

namespace TicketsSellSystem.Domain.EventAggregate.ValueObjects;

public class EventDescription : ValueObject
{
    private const int MinLength = 3;

    private const int MaxLength = 600;

    private EventDescription(string value)
    {
        ArgumentNullException.ThrowIfNull(value, nameof(value));

        value = value.Trim();

        if (value.Length is < MinLength or > MaxLength)
        {
            string exceptionMessage =
                $"Event description must have a minimum of {MinLength} characters and a maximum of {MaxLength} characters";
            throw new ArgumentException(exceptionMessage);
        }

        this.Value = value;
    }

    public string Value { get; private set; }

    public static implicit operator EventDescription(string value)
    {
        return new(value);
    }

    public static EventDescription Create(string value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return this.Value;
    }
}
