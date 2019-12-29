using System.ComponentModel.DataAnnotations.Schema;
using HahaFrame.Data.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HahaFrame.Data.Mapping
{
    public class FrameMap : EntityTypeConfiguration<Frame>
    {
        public FrameMap()
        {
            this.ToTable("Frames");
            this.HasKey(t => t.FrameId);

            this.Property(t => t.FrameViews).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            this.Property(t => t.FrameVoteCount).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            this.Property(t => t.FrameVoteAvg).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
        }
    }
}