using MediatR;
using TicketsSellSystem.Application.Events.Common;
using TicketsSellSystem.Domain.Common.Models;

namespace TicketsSellSystem.Application.Events.Commands.CreateEvent;

public record CreateEventCommand(
    string Name,
    string Description)
    : IRequest<Result<EventResult>>;