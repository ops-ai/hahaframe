using System;
using HahaFrame.Data.Core;

namespace HahaFrame.Data.Domain
{
    public class FrameView : BaseEntity
    {
        public long StatId { get; set; }

        public int FrameId { get; set; }

        public int? UserId { get; set; }

        public DateTime DateVisited { get; set; }

        public string IPAddress { get; set; }

        public byte Type { get; set; }
    }
}
