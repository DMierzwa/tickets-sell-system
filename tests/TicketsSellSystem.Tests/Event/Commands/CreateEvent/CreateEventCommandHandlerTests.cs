using FluentAssertions;
using TicketsSellSystem.Application.Events.Commands.CreateEvent;
using TicketsSellSystem.Application.Events.Common;
using TicketsSellSystem.Tests.Event.TestUtils;

namespace TicketsSellSystem.Tests.Event.Commands.CreateEvent;

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
        var command = CreateEventCommandUtils.CreateEventCommand();

        var result = await this._handler.Handle(command, default);

        result.Id.Should().NotBeEmpty();
        result.Name.Should().BeSameAs(command.Name);
        result.Description.Should().BeSameAs(command.Description);
    }

    [Fact]
    public async Task Handle_ShouldThrowException_WhenNameIsInvalid()
    {
        var command = CreateEventCommandUtils.CreateEventCommandWithoutName();

        Func<Task<EventResult>> act = async () => await this._handler.Handle(command, default);

        await act
            .Should()
            .ThrowAsync<ArgumentException>()
            .WithMessage("Event name must have a minimum of 3 characters and a maximum of 150 characters");
    }
}