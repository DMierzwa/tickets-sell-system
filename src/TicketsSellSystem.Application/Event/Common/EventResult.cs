namespace TicketsSellSystem.Application.Event.Common;

public record EventResult(
    Guid Id,
    string Name,
    string Description);