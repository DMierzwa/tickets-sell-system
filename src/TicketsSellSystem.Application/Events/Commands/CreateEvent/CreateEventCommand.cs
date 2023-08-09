using MediatR;
using TicketsSellSystem.Application.Events.Common;

namespace TicketsSellSystem.Application.Events.Commands.CreateEvent;

public record CreateEventCommand(
    string Name,
    string Description)
    : IRequest<EventResult>;