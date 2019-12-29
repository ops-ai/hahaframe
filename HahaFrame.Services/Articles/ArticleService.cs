using System.Collections.Generic;
using System.Linq;
using HahaFrame.Data.Domain;
using HahaFrame.Data.Repository;

namespace HahaFrame.Services.Articles
{
    public class ArticleService : IArticleService
    {
        private readonly IRepository<Article> _articleRepository;

        public ArticleService(IRepository<Article> articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public IList<Article> GetArticles()
        {
            var query = _articleRepository.Table;

            query = from t in query
                    where !t.Deleted
                    select t;

            return query.ToList();
        }

        public Article GetArticleById(int id)
        {
            return _articleRepository.GetById(id);
        }
    }
}
