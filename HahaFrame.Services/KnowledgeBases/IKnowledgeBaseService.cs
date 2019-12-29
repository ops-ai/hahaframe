using System.Collections.Generic;
using HahaFrame.Data.Domain;

namespace HahaFrame.Services.KnowledgeBases
{
    public partial interface IKnowledgeBaseService
    {
        IList<KnowledgeBase> GetKnowledgeBases();

        IList<KnowledgeBaseCategory> GetKnowledgeBaseCategories();
    }
}
