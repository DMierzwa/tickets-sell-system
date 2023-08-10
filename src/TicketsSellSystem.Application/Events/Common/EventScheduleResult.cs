namespace TicketsSellSystem.Application.Events.Common;

public record EventScheduleResult(
    Guid Id,
    Guid EventId,
    DateTime StartDate,
    bool IsActive);