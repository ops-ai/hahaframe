using HahaFrame.Data.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HahaFrame.Data.Mapping
{
    public class StaticPageMap : EntityTypeConfiguration<StaticPage>
    {
        public StaticPageMap()
        {
            this.ToTable("StaticPages");
            this.HasKey(t => t.PageID);
        }
    }
}