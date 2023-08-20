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
        Task<Result<EventName>> eventNameTask = EventName.CreateAsync(request.Name);
        Task<Result<EventDescription>> eventDescriptionTask = EventDescription.CreateAsync(request.Description);

        List<Task> tasks = new()
        {
            eventNameTask,
            eventDescriptionTask,
        };
        await Task.WhenAll(tasks);

        Result<EventName> eventNameResult = await eventNameTask;
        Result<EventDescription> eventDescriptionResult = await eventDescriptionTask;

        Result combinedResults = Result.CombinedResults(eventNameResult, eventDescriptionResult);
        if (!combinedResults.IsOk)
        {
            return Result<EventResult>.ErrorWithCombinedErrorMessages(combinedResults);
        }

        Event @event = Event.Create(eventNameResult.Value, eventDescriptionResult.Value);

        EventResult result = new(
            @event.Id.Value,
            @event.Name.Value,
            @event.Description.Value);

        return result;
    }
}