
using System;
using EduHub.Application.Interfaces;
using EduHub.Application.Services;
using EduHub.Domain.Entities;
using Moq;
using Xunit;

namespace EduHub.Tests;

public class EventServiceTests
{
    [Fact]
    public void CreateEvent_ValidData_ShouldCallAddAndSendOnce()
    {
        // Arrange
        var repositoryMock = new Mock<IEventRepository>();
        var notificationMock = new Mock<INotificationService>();

        var service = new EventService(
            repositoryMock.Object,
            notificationMock.Object);

        // Act
        var result = service.CreateEvent(
            Guid.NewGuid(),
            "IT Workshop",
            DateTime.UtcNow.AddDays(1),
            50);

        // Assert
        Assert.NotNull(result);

        repositoryMock.Verify(
            r => r.Add(It.IsAny<Event>()),
            Times.Once());

        notificationMock.Verify(
            n => n.Send(It.IsAny<string>()),
            Times.Once());
    }
}
