using System.Collections.Generic;
using System.Linq;
using HahaFrame.Data.Domain;
using HahaFrame.Data.Repository;

namespace HahaFrame.Services.StaticPages
{
    public class StaticPageService : IStaticPageService
    {
        private readonly IRepository<StaticPage> _staticPageRepository;

        public StaticPageService(IRepository<StaticPage> staticPageRepository)
        {
            _staticPageRepository = staticPageRepository;
        }

        public StaticPage GetStaticPageByName(string name)
        {
            var query = _staticPageRepository.Table;

            query = from t in query
                    where t.WebName.Equals(name, System.StringComparison.CurrentCultureIgnoreCase) && !t.Deleted
                    select t;

            return query.FirstOrDefault();
        }

        public StaticPage GetStaticPageById(int pageId)
        {
            return _staticPageRepository.GetById(pageId);
        }
    }
}
