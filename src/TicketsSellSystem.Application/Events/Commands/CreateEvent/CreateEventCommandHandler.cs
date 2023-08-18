using MediatR;
using TicketsSellSystem.Application.Events.Common;
using TicketsSellSystem.Domain.Common.Models;
using TicketsSellSystem.Domain.EventAggregate;
using TicketsSellSystem.Domain.EventAggregate.ValueObjects;

namespace TicketsSellSystem.Application.Events.Commands.CreateEvent;

public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Result<EventResult>>
{
    public async Task<Result<EventResult>> Handle(CreateEventCommand request, CancellationToken cancellationToken)
    {
        Result<EventName> eventNameResult = await EventName.CreateAsync(request.Name);

        if (!eventNameResult.IsOk)
        {
            return Result<EventResult>.Error(eventNameResult.ErrorMessage);
        }

        Event @event = Event.Create(eventNameResult.Value, request.Description);

        EventResult result = new(
            @event.Id.Value,
            @event.Name.Value,
            @event.Description.Value);

        return result;
    }
}