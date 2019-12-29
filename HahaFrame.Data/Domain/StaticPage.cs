using System;
using HahaFrame.Data.Core;

namespace HahaFrame.Data.Domain
{
    public class StaticPage : BaseEntity
    {
        public int PageID { get; set; }

        public string MetaTitle { get; set; }

        public string MetaDescription { get; set; }

        public string PageBody { get; set; }

        public bool Active { get; set; }

        public string WebName { get; set; }

        public bool Deleted { get; set; }
    }
}