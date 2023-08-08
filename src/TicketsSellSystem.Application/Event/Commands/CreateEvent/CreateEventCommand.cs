using MediatR;
using TicketsSellSystem.Application.Event.Common;

namespace TicketsSellSystem.Application.Event.Commands.CreateEvent;

public record CreateEventCommand(
    string Name,
    string Description)
    : IRequest<EventResult>;