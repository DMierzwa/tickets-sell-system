using FluentAssertions;
using TicketsSellSystem.Application.Events.Commands.CreateEvent;
using TicketsSellSystem.Application.Events.Common;
using TicketsSellSystem.Domain.Common.Models;
using TicketsSellSystem.Tests.Event.TestUtils;
using TicketsSellSystem.Tests.TestUtils;

namespace TicketsSellSystem.Tests.Event.Commands.CreateEvent;

public class CreateEventCommandHandlerTests
{
    private readonly CreateEventCommandHandler _handler;

    public CreateEventCommandHandlerTests()
    {
        this._handler = new CreateEventCommandHandler();
    }

    [Fact]
    public async Task Handle_WithValidCreateEventCommand_ReturnOk()
    {
        var command = CreateEventCommandUtils.CreateValidEventCommand();

        Result<EventResult> result = await this._handler.Handle(command, CancellationToken.None);

        result.IsOk.Should().BeTrue();
    }

    [Fact]
    public async Task Handle_WithValidCreateEventCommand_ReturnValidEventId()
    {
        var command = CreateEventCommandUtils.CreateValidEventCommand();

        Result<EventResult> result = await this._handler.Handle(command, CancellationToken.None);

        Assert.NotNull(result.Value?.Id);
        Assert.True(Guid.TryParse(result.Value!.Id.ToString(), out Guid id));
    }

    [Theory]
    [ClassData(typeof(InvalidStringData))]
    public async Task Handle_WithInvalidEventName_ReturnFalseIsOk(string name)
    {
        var command = CreateEventCommandUtils.CreateEventCommandWithInvalidName(name);

        var result = await this._handler.Handle(command, CancellationToken.None);

        Assert.False(result.IsOk);
    }

    [Theory]
    [ClassData(typeof(InvalidStringData))]
    public async Task Handle_WithInvalidEventName_ReturnErrorMessage(string name)
    {
        var command = CreateEventCommandUtils.CreateEventCommandWithInvalidName(name);

        var result = await this._handler.Handle(command, CancellationToken.None);

        Assert.Equal("Event name must have a minimum of 1 characters and a maximum of 150 characters", result.ErrorMessage);
    }
}