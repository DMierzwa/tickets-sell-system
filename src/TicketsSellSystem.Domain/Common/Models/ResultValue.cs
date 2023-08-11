namespace TicketsSellSystem.Domain.Common.Models;

public readonly struct Result<TValue>
{
    public readonly TValue Value;
    public readonly string ErrorMessage;

    private readonly bool _isOk;

    private Result(
        TValue value,
        string errorMessage,
        bool isOk)
    {
        this.Value = value;
        this.ErrorMessage = errorMessage;
        this._isOk = isOk;
    }

    public bool IsOk => this._isOk;

    public static implicit operator Result<TValue>(TValue value)
    {
        return new(value, string.Empty, true);
    }

    public static Result<TValue> Ok(TValue value)
    {
        return new(value, string.Empty, true);
    }

    public static Result<TValue> Error(string message)
    {
        return new(default!, message, false);
    }
}