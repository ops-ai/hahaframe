using HahaFrame.Data.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HahaFrame.Data.Mapping
{
    public class KnowledgeBaseCategoryMap : EntityTypeConfiguration<KnowledgeBaseCategory>
    {
        public KnowledgeBaseCategoryMap()
        {
            this.ToTable("KnowledgeBaseCategories");
            this.HasKey(t => t.CategoryID);
        }
    }
}