using System;
using HahaFrame.Data.Core;

namespace HahaFrame.Data.Domain
{
    public class FrameVote : BaseEntity
    {
        public long VoteId { get; set; }

        public int FrameId { get; set; }

        public int UserId { get; set; }

        public DateTime DatePosted { get; set; }

        public string IPAddress { get; set; }

        public byte VoteValue { get; set; }

        public bool Deleted { get; set; }
    }
}
