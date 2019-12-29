using System.Collections.Generic;
using HahaFrame.Data.Domain;

namespace HahaFrame.Services.Articles
{
    public partial interface IArticleService
    {
        IList<Article> GetArticles();

        Article GetArticleById(int id);
    }
}
