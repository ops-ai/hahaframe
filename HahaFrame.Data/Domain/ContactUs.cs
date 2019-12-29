using System;
using HahaFrame.Data.Core;

namespace HahaFrame.Data.Domain
{
    public class ContactUs : BaseEntity
    {
        public int ContactId { get; set; }

        public DateTime DateSubmitted { get; set; }

        public string Email { get; set; }

        public string FullName { get; set; }

        public string Message { get; set; }

        public string Regarding { get; set; }

        public bool Deleted { get; set; }
    }
}
