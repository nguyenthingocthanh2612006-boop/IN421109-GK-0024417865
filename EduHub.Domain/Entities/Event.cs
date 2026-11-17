using System;
using System.Collections.Generic;
using System.Text;

namespace EduHub.Domain.Entities
{
    public class Event
    {
        public Guid Id { get; private set; }
        public Guid ClubId { get; private set; }
        public string Title { get; private set; }
        public DateTime Date { get; private set; }
        public int Capacity { get; private set; }

        private Event()
        {
            Title = string.Empty;
        }

        public static Event Create(
            Guid clubId,
            string title,
            DateTime date,
            int capacity)
        {
            if (clubId == Guid.Empty)
                throw new ArgumentException("Invalid club ID");

            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Title is required");

            if (capacity <= 0)
                throw new ArgumentException("Capacity must be greater than zero");

            return new Event
            {
                Id = Guid.NewGuid(),
                ClubId = clubId,
                Title = title.Trim(),
                Date = date,
                Capacity = capacity
            };
        }
    }
}
