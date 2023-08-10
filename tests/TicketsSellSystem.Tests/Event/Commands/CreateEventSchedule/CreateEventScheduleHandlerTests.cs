using FluentAssertions;
using TicketsSellSystem.Application.Events.Commands.CreateEventSchedule;
using TicketsSellSystem.Tests.Event.TestUtils;

namespace TicketsSellSystem.Tests.Event.Commands.CreateEventSchedule;

public class CreateEventScheduleCommandHandlerTests
{
    private readonly CreateEventScheduleCommandHandler _handler;

    public CreateEventScheduleCommandHandlerTests()
    {
        this._handler = new CreateEventScheduleCommandHandler();
    }

    [Fact]
    public async Task Handle_ShouldCreateEventSchedule_WhenEventScheduleIsValid()
    {
        var command = CreateEventScheduleCommandUtils.Command();

        Func<Task> act = async () => await this._handler.Handle(command, default);

        await act.Should().NotThrowAsync();
    }
}