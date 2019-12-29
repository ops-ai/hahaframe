using System;
using HahaFrame.Data.Core;

namespace HahaFrame.Data.Domain
{
    public class FlaggedContent : BaseEntity
    {
        public long FlagId { get; set; }

        public int UserId { get; set; }

        public int ReferenceId { get; set; }

        public byte ReferenceType { get; set; }

        public DateTime DateFlagged { get; set; }

        public string IPAddress { get; set; }
    }
}
