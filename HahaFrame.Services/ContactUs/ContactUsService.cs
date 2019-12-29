using System;
using System.Collections.Generic;
using System.Linq;
using HahaFrame.Data.Repository;

namespace HahaFrame.Services.ContactUs
{
    public class ContactUsService : IContactUsService
    {
        private readonly IRepository<Data.Domain.ContactUs> _contactUsRepository;

        public ContactUsService(IRepository<Data.Domain.ContactUs> contactUsRepository)
        {
            _contactUsRepository = contactUsRepository;
        }

        public void SubmitContactUs(Data.Domain.ContactUs message)
        {
            message.DateSubmitted = DateTime.Now;
            message.Deleted = false;

            _contactUsRepository.Insert(message);
        }

        public void DeleteMessage(int messageId)
        {
            var message = _contactUsRepository.GetById(messageId);
            message.Deleted = true;

            _contactUsRepository.Update(message);
        }

        public IList<Data.Domain.ContactUs> GetList()
        {
            var query = _contactUsRepository.Table;

            query = from t in query
                    where !t.Deleted
                    select t;

            return query.ToList();
        }
    }
}
