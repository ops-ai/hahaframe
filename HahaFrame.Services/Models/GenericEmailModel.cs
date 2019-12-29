using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HahaFrame.Services.Emails
{
    public class GenericEmailModel
    {
        public string ToEmail { get; set; }

        public string FromEmail { get; set; }

        public string FullName { get; set; }

        public string Message { get; set; }

        public string Subject { get; set; }
    }
}