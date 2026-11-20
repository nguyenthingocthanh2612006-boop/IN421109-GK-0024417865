using System;
using System.Collections.Generic;
using System.Text;

namespace EduHub.Domain.Entities
{
    public class Registration
    {
        public Guid Id { get; private set; }
        public Guid MemberId { get; private set; }
        public Guid EventId { get; private set; }
        public DateTime RegisteredAt { get; private set; }
        public RegistrationStatus Status { get; private set; }

        private Registration() { }

        public static Registration Create(Guid memberId, Guid eventId)
        {
            if (memberId == Guid.Empty || eventId == Guid.Empty)
                throw new ArgumentException("Invalid member or event ID");

            return new Registration
            {
                Id = Guid.NewGuid(),
                MemberId = memberId,
                EventId = eventId,
                RegisteredAt = DateTime.UtcNow,
                Status = RegistrationStatus.Pending
            };
        }

        public void Confirm()
        {
            if (Status != RegistrationStatus.Pending)
                throw new InvalidOperationException("Only pending registrations can be confirmed");
            Status = RegistrationStatus.Confirmed;
        }

        public void Cancel()
        {
            if (Status == RegistrationStatus.Cancelled)
                throw new InvalidOperationException("Registration is already cancelled");
            Status = RegistrationStatus.Cancelled;
        }
    }
}
