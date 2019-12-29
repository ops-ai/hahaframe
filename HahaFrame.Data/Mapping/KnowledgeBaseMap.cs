using HahaFrame.Data.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HahaFrame.Data.Mapping
{
    public class KnowledgeBaseMap : EntityTypeConfiguration<KnowledgeBase>
    {
        public KnowledgeBaseMap()
        {
            this.ToTable("KnowledgeBases");
            this.HasKey(t => t.ItemID);
        }
    }
}