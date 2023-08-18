using TicketsSellSystem.Domain.Common.Models;

namespace TicketsSellSystem.Domain.EventAggregate.ValueObjects;

public class EventName : ValueObject
{
    private const int MinLength = 1;

    private const int MaxLength = 150;

    private EventName(string value)
    {
        this.Value = value;
    }

    public string Value { get; private set; }

    public static Result<EventName> Create(string value)
    {
        value = (value ?? string.Empty).Trim();
        if (value.Length < MinLength || value.Length > MaxLength)
        {
            string exceptionMessage =
                $"Event name must have a minimum of {MinLength} characters and a maximum of {MaxLength} characters";

            return Result<EventName>.Error(exceptionMessage);
        }

        return new EventName(value);
    }

    public static Task<Result<EventName>> CreateAsync(string value)
    {
        return Task.Run(() => Create(value));
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return this.Value;
    }
}