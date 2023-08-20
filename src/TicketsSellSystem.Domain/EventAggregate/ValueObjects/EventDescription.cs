using TicketsSellSystem.Domain.Common.Models;

namespace TicketsSellSystem.Domain.EventAggregate.ValueObjects;

public class EventDescription : ValueObject
{
    private const int MinLength = 1;

    private const int MaxLength = 600;

    private EventDescription(string value)
    {
        this.Value = value;
    }

    public string Value { get; private set; }

    public static Result<EventDescription> Create(string value)
    {
        value = (value ?? string.Empty).Trim();
        if (value.Length is < MinLength or > MaxLength)
        {
            string exceptionMessage =
                $"Event description must have a minimum of {MinLength} characters and a maximum of {MaxLength} characters";

            return Result<EventDescription>.Error(exceptionMessage);
        }

        return new EventDescription(value);
    }

    public static Task<Result<EventDescription>> CreateAsync(string value)
    {
        return Task.Run(() => Create(value));
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return this.Value;
    }
}