
using System;
using EduHub.Domain.Entities;
using Xunit;

namespace EduHub.Tests;

public class RegistrationTests
{
    [Fact]
    public void Create_ShouldSetStatusToPending()
    {
        var registration = Registration.Create(
            Guid.NewGuid(), Guid.NewGuid());

        Assert.Equal(
            RegistrationStatus.Pending,
            registration.Status);
    }

    [Fact]
    public void Confirm_ShouldChangeStatusToConfirmed()
    {
        var registration = Registration.Create(
            Guid.NewGuid(), Guid.NewGuid());

        registration.Confirm();

        Assert.Equal(
            RegistrationStatus.Confirmed,
            registration.Status);
    }

    [Fact]
    public void Confirm_AfterCancel_ShouldThrowAndRemainCancelled()
    {
        var registration = Registration.Create(
            Guid.NewGuid(), Guid.NewGuid());

        registration.Cancel();

        Assert.Throws<InvalidOperationException>(
            () => registration.Confirm());

        Assert.Equal(
            RegistrationStatus.Cancelled,
            registration.Status);
    }
}
