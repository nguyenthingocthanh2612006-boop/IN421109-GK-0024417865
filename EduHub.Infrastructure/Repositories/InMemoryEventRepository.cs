
using EduHub.Application.Interfaces;
using EduHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace EduHub.Infrastructure.Repositories;

public class InMemoryEventRepository : IEventRepository
{
    private readonly List<Event> _events = new();

    public void Add(Event eventItem)
    {
        _events.Add(eventItem);
    }

    public Event? GetById(Guid id)
    {
        return _events.FirstOrDefault(e => e.Id == id);
    }

    public IEnumerable<Event> GetByClubId(Guid clubId)
    {
        return _events.Where(e => e.ClubId == clubId).ToList();
    }

    public bool Delete(Guid id)
    {
        var eventItem = GetById(id);

        if (eventItem == null)
            return false;

        _events.Remove(eventItem);
        return true;
    }
}
