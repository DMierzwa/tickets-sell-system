namespace TicketsSellSystem.Domain.Common.Models;

public record class Result<TValue> : Result
{
    private Result(
        TValue value,
        string errorMessage,
        bool isOk)
        : this(
            value,
            errorMessage,
            isOk,
            Array.Empty<string>())
    {
    }

    private Result(
        TValue value,
        string errorMessage,
        bool isOk,
        string[] combinedErrorMessages)
        : base(
            errorMessage,
            isOk,
            combinedErrorMessages)
    {
        this.Value = value;
    }

    public TValue Value { get; private set; }

    public static implicit operator Result<TValue>(TValue value)
    {
        return Ok(value);
    }

    public static Result<TValue> Ok(TValue value)
    {
        return new(value, string.Empty, true);
    }

    public static new Result<TValue> Error(string message)
    {
        return new Result<TValue>(default!, message, false);
    }

    public static new Result<TValue> ErrorWithCombinedErrorMessages(Result result)
    {
        return new Result<TValue>(
            default!,
            result.ErrorMessage,
            false,
            result.CombinedErrorMessages);
    }
}