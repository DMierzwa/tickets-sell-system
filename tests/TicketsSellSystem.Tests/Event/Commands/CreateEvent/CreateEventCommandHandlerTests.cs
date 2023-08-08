using FluentAssertions;
using TicketsSellSystem.Application.Event.Commands.CreateEvent;

namespace TicketSellSystem.Tests.Event.Commands.CreateEvent;

public class CreateEventCommandHandlerTests
{
    private readonly CreateEventCommandHandler _handler;

    public CreateEventCommandHandlerTests()
    {
        this._handler = new CreateEventCommandHandler();
    }

    [Fact]
    public async Task Handle_ShouldCreateAndReturnEvent_WhenEventIsValid()
    {
        var command = new CreateEventCommand("event name", "event description");

        var result = await this._handler.Handle(command, default);

        result.Id.Should().NotBeEmpty();
        result.Name.Should().BeSameAs("event name");
        result.Description.Should().BeSameAs("event description");
    }
}