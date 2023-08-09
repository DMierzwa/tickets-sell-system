using TicketsSellSystem.Domain.Common.Models;

namespace TicketsSellSystem.Domain.EventAggregate.ValueObjects;

public class EventName : ValueObject
{
    private const int MinLength = 3;

    private const int MaxLength = 150;

    private EventName(string value)
    {
        ArgumentNullException.ThrowIfNull(value, nameof(value));

        value = value.Trim();

        if (value.Length < MinLength || value.Length > MaxLength)
        {
            string exceptionMessage =
                $"Event name must have a minimum of {MinLength} characters and a maximum of {MaxLength} characters";
            throw new ArgumentException(exceptionMessage);
        }

        this.Value = value;
    }

    public string Value { get; private set; }

    public static implicit operator EventName(string value)
    {
        return new(value);
    }

    public static EventName Create(string value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return this.Value;
    }
}