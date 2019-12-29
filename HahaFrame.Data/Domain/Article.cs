using System;
using HahaFrame.Data.Core;

namespace HahaFrame.Data.Domain
{
    public class Article : BaseEntity
    {
        public int ArticleID { get; set; }

        public string ArticleTitle { get; set; }

        public string MetaKeywords { get; set; }

        public string MetaDescription { get; set; }

        public string ArticleContent { get; set; }

        public int CategoryID { get; set; }

        public DateTime DateAdded { get; set; }

        public bool Deleted { get; set; }
    }
}
