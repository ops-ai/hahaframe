using System.Collections.Generic;
using System.Linq;
using HahaFrame.Data.Domain;
using HahaFrame.Data.Repository;

namespace HahaFrame.Services.KnowledgeBases
{
    public class KnowledgeBaseService : IKnowledgeBaseService
    {
        private readonly IRepository<KnowledgeBase> _knowledgeBaseRepository;
        private readonly IRepository<KnowledgeBaseCategory> _knowledgeBaseCategoryRepository;

        public KnowledgeBaseService(IRepository<KnowledgeBase> knowledgeBaseRepository, IRepository<KnowledgeBaseCategory> knowledgeBaseCategoryRepository)
        {
            _knowledgeBaseRepository = knowledgeBaseRepository;
            _knowledgeBaseCategoryRepository = knowledgeBaseCategoryRepository;
        }

        public IList<KnowledgeBase> GetKnowledgeBases()
        {
            var query = _knowledgeBaseRepository.Table;

            query = from t in query
                    where !t.Deleted
                    select t;

            return query.ToList();
        }

        public IList<KnowledgeBaseCategory> GetKnowledgeBaseCategories()
        {
            var query = _knowledgeBaseCategoryRepository.Table;

            query = from t in query
                    where !t.Deleted
                    select t;

            return query.ToList();
        }
    }
}
