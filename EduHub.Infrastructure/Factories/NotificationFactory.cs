
using System;
using EduHub.Application.Interfaces;
using EduHub.Infrastructure.Notifications;

namespace EduHub.Infrastructure.Factories;

public class NotificationFactory
{
    private readonly EmailNotificationService _email;
    private readonly SmsNotificationService _sms;

    public NotificationFactory(
        EmailNotificationService email,
        SmsNotificationService sms)
    {
        _email = email;
        _sms = sms;
    }

    public INotificationService Create(string channel)
    {
        return channel?.ToLowerInvariant() switch
        {
            "email" => _email,
            "sms" => _sms,
            _ => throw new ArgumentException(
                "Unsupported notification channel")
        };
    }
}
