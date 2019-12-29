using System;
using HahaFrame.Data.Core;

namespace HahaFrame.Data.Domain
{
    public class FrameCategory : BaseEntity
    {
        public int CategoryId { get; set; }

        public string Name { get; set; }

        public string WebName { get; set; }

        public bool Deleted { get; set; }

        public bool Special { get; set; }

        public int? ParentCategoryId { get; set; }

        public string MetaDescription { get; set; }
    }
}
