using System;
using System.Collections.Generic;
using System.Text;

namespace EduHub.Domain.Entities
{
    public class Member
    {
        public Guid Id { get; private set; }
        public string Email { get; private set; }

        private Member()
        {
            Email = string.Empty;
        }

        public static Member Create(string email)
        {
            if (string.IsNullOrWhiteSpace(email) ||
                !email.Contains('@'))
            {
                throw new ArgumentException("Invalid email");
            }

            return new Member
            {
                Id = Guid.NewGuid(),
                Email = email.Trim()
            };
        }
    }
}
