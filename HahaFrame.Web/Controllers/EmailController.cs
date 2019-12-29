using ActionMailer.Net.Mvc;
using HahaFrame.Data.Domain;
using HahaFrame.Services.Emails;

namespace HahaFrame.Web.Controllers
{
    public class EmailNotificationController : MailerBase, IEmailNotificationService
    {
        public EmailResult SendWelcomeEmail(string emailAddress)
        {
            From = System.Configuration.ConfigurationManager.AppSettings["SalesEmail"];
            To.Add(emailAddress);
            Subject = System.Configuration.ConfigurationManager.AppSettings["SiteName"] + " Mailing List Subscription Confirmation";
            SendHtml = true;

            return Email("WelcomeEmail", emailAddress);
        }

        public EmailResult SendContactUsEmail(ContactUs model)
        {
            From = System.Configuration.ConfigurationManager.AppSettings["SalesEmail"];
            ReplyTo.Add(model.Email);
            To.Add(System.Configuration.ConfigurationManager.AppSettings["SalesEmail"]);
            Subject = "New Message from the " + System.Configuration.ConfigurationManager.AppSettings["SiteName"];
            SendHtml = true;

            return Email("ContactUsEmail", model);
        }

        public EmailResult SendEmailGeneric(GenericEmailModel model)
        {
            From = model.FromEmail;
            To.Add(model.ToEmail);
            Subject = model.Subject;
            SendHtml = true;
            return Email("SendEmailGeneric", model);
        }
    }
}