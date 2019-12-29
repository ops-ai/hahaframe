using System;
using HahaFrame.Data.Core;

namespace HahaFrame.Data.Domain
{
    public class Global : BaseEntity
    {
        public int GlobalID { get; set; }

        public string Variable { get; set; }

        public string Value { get; set; }

        public DateTime LastModified { get; set; }

        public bool Deleted { get; set; }
    }
}
