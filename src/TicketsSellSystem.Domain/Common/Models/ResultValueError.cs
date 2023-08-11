namespace TicketsSellSystem.Domain.Common.Models;

public readonly struct Result<TValue, TError>
{
    public readonly TValue Value;
    public readonly TError Error;

    private readonly bool _success;

    private Result(TValue v, TError e, bool success)
    {
        this.Value = v;
        this.Error = e;
        this._success = success;
    }

    public bool IsOk => this._success;

    public static implicit operator Result<TValue, TError>(TValue v) => new(v, default!, true);

    public static implicit operator Result<TValue, TError>(TError e) => new(default!, e, false);

    public static Result<TValue, TError> Ok(TValue v)
    {
        return new(v, default!, true);
    }

    public static Result<TValue, TError> Err(TError e)
    {
        return new(default!, e, false);
    }

    public TResult Match<TResult>(
            Func<TValue, TResult> success,
            Func<TError, TResult> failure) =>
        this._success ? success(this.Value) : failure(this.Error);
}