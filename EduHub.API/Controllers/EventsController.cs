
using Microsoft.AspNetCore.Mvc;
using EduHub.Application.Interfaces;
using EduHub.Application.Services;
using EduHub.Domain.Entities;

namespace EduHub.API.Controllers;

[ApiController]
public class EventsController : ControllerBase
{
    private readonly IEventRepository _repository;
    private readonly EventService _eventService;

    public EventsController(
        IEventRepository repository,
        EventService eventService)
    {
        _repository = repository;
        _eventService = eventService;
    }

    // GET /api/clubs/{clubId}/events
    [HttpGet("api/clubs/{clubId:guid}/events")]
    public IActionResult GetByClub(Guid clubId)
    {
        if (clubId == Guid.Empty)
            return BadRequest("Invalid club ID");

        return Ok(_repository.GetByClubId(clubId));
    }

    // GET /api/events/{id}
    [HttpGet("api/events/{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        var eventItem = _repository.GetById(id);

        if (eventItem == null)
            return NotFound();

        return Ok(eventItem);
    }

    // POST /api/clubs/{clubId}/events
    [HttpPost("api/clubs/{clubId:guid}/events")]
    public IActionResult Create(
        Guid clubId,
        [FromBody] CreateEventRequest request)
    {
        try
        {
            var eventItem = _eventService.CreateEvent(
                clubId,
                request.Title,
                request.Date,
                request.Capacity);

            return CreatedAtAction(
                nameof(GetById),
                new { id = eventItem.Id },
                eventItem);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // DELETE /api/events/{id}
    [HttpDelete("api/events/{id:guid}")]
    public IActionResult Delete(Guid id)
    {
        if (!_repository.Delete(id))
            return NotFound();

        return NoContent();
    }
}

public class CreateEventRequest
{
    public string Title { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public int Capacity { get; set; }
}
