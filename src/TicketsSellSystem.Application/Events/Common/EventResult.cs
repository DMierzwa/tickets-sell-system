namespace TicketsSellSystem.Application.Events.Common;

public record EventResult(
    Guid Id,
    string Name,
    string Description);