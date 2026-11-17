
using System;
using System.Collections.Generic;
using EduHub.Domain.Entities;

namespace EduHub.Application.Interfaces;

public interface IEventRepository
{
    void Add(Event eventItem);
    Event? GetById(Guid id);
    IEnumerable<Event> GetByClubId(Guid clubId);
    bool Delete(Guid id);
}
