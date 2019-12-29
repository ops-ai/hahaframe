using ActionMailer.Net.Mvc;
using HahaFrame.Data.Domain;

namespace HahaFrame.Services.Emails
{
    public partial interface IEmailNotificationService
    {
        EmailResult SendWelcomeEmail(string emailAddress);

        EmailResult SendEmailGeneric(GenericEmailModel model);
    }
}
