using System.Collections.Generic;

namespace HahaFrame.Services.ContactUs
{
    public partial interface IContactUsService
    {
        void SubmitContactUs(Data.Domain.ContactUs message);

        IList<Data.Domain.ContactUs>GetList();

        void DeleteMessage(int messageId);
    }
}
