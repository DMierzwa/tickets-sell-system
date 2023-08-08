using MediatR;
using TicketsSellSystem.Application.Event.Common;

namespace TicketsSellSystem.Application.Event.Commands.CreateEvent;

public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, EventResult>
{
    public async Task<EventResult> Handle(CreateEventCommand request, CancellationToken cancellationToken)
    {
        EventResult result = new(
            Guid.NewGuid(),
            request.Name,
            request.Description);

        return await Task.FromResult(result);
    }
}