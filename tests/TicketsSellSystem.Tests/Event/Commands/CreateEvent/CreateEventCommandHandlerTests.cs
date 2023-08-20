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

    [Fact]
    public async Task Handle_WithValidCreateEventCommand_ReturnValidEventName()
    {
        var command = CreateEventCommandUtils.CreateValidEventCommand();

        Result<EventResult> result = await this._handler.Handle(command, CancellationToken.None);

        Assert.Equal(command.Name, result.Value?.Name);
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

        string expectedMessage = "Combined results has errors";
        Assert.Equal(expectedMessage, result.ErrorMessage);
    }

    [Theory]
    [ClassData(typeof(InvalidStringData))]
    public async Task Handle_WithInvalidEventName_ReturnCombinedErrorMessage(string name)
    {
        var command = CreateEventCommandUtils.CreateEventCommandWithInvalidName(name);

        var result = await this._handler.Handle(command, CancellationToken.None);

        string expectedMessage = "Event name must have a minimum of 1 characters and a maximum of 150 characters";
        Assert.Equal(expectedMessage, result.CombinedErrorMessages[0]);
    }

    [Fact]
    public async Task Handle_WithValidCreateEventCommand_ReturnValidEventDescription()
    {
        var command = CreateEventCommandUtils.CreateValidEventCommand();

        Result<EventResult> result = await this._handler.Handle(command, CancellationToken.None);

        Assert.Equal(command.Description, result.Value?.Description);
    }

    [Theory]
    [ClassData(typeof(InvalidStringData))]
    public async Task Handle_WithInvalidEventDescription_ReturnFalseIsOk(string description)
    {
        var command = CreateEventCommandUtils.CreateEventCommandWithInvalidDescription(description);

        var result = await this._handler.Handle(command, CancellationToken.None);

        Assert.False(result.IsOk);
    }

    [Theory]
    [ClassData(typeof(InvalidStringData))]
    public async Task Handle_WithInvalidEventDescription_ReturnErrorMessage(string name)
    {
        var command = CreateEventCommandUtils.CreateEventCommandWithInvalidName(name);

        var result = await this._handler.Handle(command, CancellationToken.None);

        string expectedMessage = "Combined results has errors";
        Assert.Equal(expectedMessage, result.ErrorMessage);
    }

    [Theory]
    [ClassData(typeof(InvalidStringData))]
    public async Task Handle_WithInvalidEventDescription_ReturnCombinedErrorMessage(string name)
    {
        var command = CreateEventCommandUtils.CreateEventCommandWithInvalidDescription(name);

        var result = await this._handler.Handle(command, CancellationToken.None);

        string expectedMessage = "Event description must have a minimum of 1 characters and a maximum of 600 characters";
        Assert.Equal(expectedMessage, result.CombinedErrorMessages[0]);
    }
}