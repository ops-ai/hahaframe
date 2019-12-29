using HahaFrame.Data.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HahaFrame.Data.Mapping
{
    public class FrameVoteMap : EntityTypeConfiguration<FrameVote>
    {
        public FrameVoteMap()
        {
            this.ToTable("FrameVotes");
            this.HasKey(t => t.VoteId);
        }
    }
}