using HahaFrame.Data.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HahaFrame.Data.Mapping
{
    public class ContactUsMap : EntityTypeConfiguration<ContactUs>
    {
        public ContactUsMap()
        {
            this.ToTable("ContactUs");
            this.HasKey(t => t.ContactId);
        }
    }
}