using System;
using HahaFrame.Data.Core;

namespace HahaFrame.Data.Domain
{
    public class Frame : BaseEntity
    {
        public int FrameId { get; set; }

        public string PhotoUrl { get; set; }

        public string Title { get; set; }

        public string MetaDescription { get; set; }

        public bool Deleted { get; set; }

        public bool Active { get; set; }

        public int UserId { get; set; }

        public int CategoryId { get; set; }

        public string WebName { get; set; }

        public DateTime DateUploaded { get; set; }

        public bool Featured { get; set; }

        public long FrameViews { get; set; }

        public long FrameVoteCount { get; set; }

        public double? FrameVoteAvg { get; set; }
    }
}
