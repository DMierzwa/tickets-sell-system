using MediatR;
using TicketsSellSystem.Application.Events.Common;
using TicketsSellSystem.Domain.EventAggregate;

namespace TicketsSellSystem.Application.Events.Commands.CreateEvent;

public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, EventResult>
{
    public async Task<EventResult> Handle(CreateEventCommand request, CancellationToken cancellationToken)
    {
        Event @event = Event.Create(request.Name, request.Description);

        EventResult result = new(
            @event.Id.Value,
            @event.Name.Value,
            @event.Description.Value);

        return await Task.FromResult(result);
    }
}