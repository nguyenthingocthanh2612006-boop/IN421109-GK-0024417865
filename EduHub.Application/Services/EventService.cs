
using System;
using EduHub.Application.Interfaces;
using EduHub.Domain.Entities;

namespace EduHub.Application.Services;

public class EventService
{
    private readonly IEventRepository _repository;
    private readonly INotificationService _notification;

    public EventService(
        IEventRepository repository,
        INotificationService notification)
    {
        _repository = repository;
        _notification = notification;
    }

    public Event CreateEvent(
        Guid clubId,
        string title,
        DateTime date,
        int capacity)
    {
        var eventItem = Event.Create(
            clubId, title, date, capacity);

        _repository.Add(eventItem);

        _notification.Send(
            $"New event: {eventItem.Title}");

        return eventItem;
    }
}
