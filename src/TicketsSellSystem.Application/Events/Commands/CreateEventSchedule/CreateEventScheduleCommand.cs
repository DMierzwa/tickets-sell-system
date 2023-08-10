using MediatR;

namespace TicketsSellSystem.Application.Events.Commands.CreateEventSchedule;

public record CreateEventScheduleCommand(
    Guid EventId,
    DateTime StartDate,
    bool IsActive)
    : IRequest;