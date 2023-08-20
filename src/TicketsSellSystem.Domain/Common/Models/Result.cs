namespace TicketsSellSystem.Domain.Common.Models;

public record class Result
{
    protected Result(
        string errorMessage,
        bool isOk)
        : this(errorMessage, isOk, Array.Empty<string>())
    {
    }

    protected Result(
        string errorMessage,
        bool isOk,
        string[] combinedErrorMessages)
    {
        this.ErrorMessage = errorMessage;
        this.IsOk = isOk;
        this.CombinedErrorMessages = combinedErrorMessages;
    }

    public bool IsOk { get; private set; }

    public string ErrorMessage { get; private set; }

    public string[] CombinedErrorMessages { get; private set; }

    public static Result Ok()
    {
        return new(string.Empty, true);
    }

    public static Result Error(string message)
    {
        return new(message, false);
    }

    public static Result ErrorWithCombinedErrorMessages(Result result)
    {
        return new(
            result.ErrorMessage,
            false,
            result.CombinedErrorMessages);
    }

    public static Result CombinedResults(params Result[] results)
    {
        bool isError = false;
        int resultsLength = results.Length;
        List<string> errorsMessages = new();

        for (int i = 0; i < resultsLength; i++)
        {
            Result result = results[i];

            if (result.IsOk)
            {
                continue;
            }

            isError = true;
            errorsMessages.Add(result.ErrorMessage);
        }

        if (isError)
        {
            return new(
                "Combined results has errors",
                false,
                errorsMessages.ToArray());
        }

        return Ok();
    }
}
