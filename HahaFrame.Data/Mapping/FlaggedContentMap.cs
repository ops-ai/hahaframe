using HahaFrame.Data.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HahaFrame.Data.Mapping
{
    public class FlaggedContentMap : EntityTypeConfiguration<FlaggedContent>
    {
        public FlaggedContentMap()
        {
            this.ToTable("FlaggedContent");
            this.HasKey(t => t.FlagId);
        }
    }
}