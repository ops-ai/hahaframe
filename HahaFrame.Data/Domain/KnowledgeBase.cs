using System;
using HahaFrame.Data.Core;

namespace HahaFrame.Data.Domain
{
    public class KnowledgeBase : BaseEntity
    {
        public int ItemID { get; set; }

        public string ItemTitle { get; set; }

        public string ItemContent { get; set; }

        public int CategoryID { get; set; }

        public DateTime DateAdded { get; set; }

        public bool Deleted { get; set; }
    }
}