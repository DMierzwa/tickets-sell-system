using MediatR;
using TicketsSellSystem.Domain.EventAggregate.Entities;
using TicketsSellSystem.Domain.EventAggregate.ValueObjects;

namespace TicketsSellSystem.Application.Events.Commands.CreateEventSchedule;

public class CreateEventScheduleCommandHandler
    : IRequestHandler<CreateEventScheduleCommand>
{
    public async Task Handle(CreateEventScheduleCommand request, CancellationToken cancellationToken)
    {
        EventSchedule eventSchedule =
            EventSchedule.Create(
                EventId.Create(request.EventId),
                request.StartDate,
                request.IsActive);

        // Event @event = Event.Create();
        // @event.AddEventSchedule(eventSchedule);
        await Task.Delay(100);
    }
}
