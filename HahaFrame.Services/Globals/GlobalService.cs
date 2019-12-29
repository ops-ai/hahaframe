using System.Linq;
using HahaFrame.Data.Repository;

namespace HahaFrame.Services.Globals
{
    public class GlobalService : IGlobalService
    {
        private readonly IRepository<HahaFrame.Data.Domain.Global> _globalRepository;

        public GlobalService(IRepository<HahaFrame.Data.Domain.Global> globalRepository)
        {
            _globalRepository = globalRepository;
        }

        public string GetGlobalMessage(string key)
        {
            var query = _globalRepository.Table;

            query = from t in query
                    where !t.Deleted && t.Variable.Equals(key, System.StringComparison.CurrentCultureIgnoreCase)
                    select t;

            return query.Select(t => t.Value).FirstOrDefault();
        }
    }
}
