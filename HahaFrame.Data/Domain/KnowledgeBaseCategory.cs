using System;
using HahaFrame.Data.Core;

namespace HahaFrame.Data.Domain
{
    public class KnowledgeBaseCategory : BaseEntity
    {
        public int CategoryID { get; set; }

        public string Name { get; set; }

        public DateTime DateAdded { get; set; }

        public bool Deleted { get; set; }
    }
}
