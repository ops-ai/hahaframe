using System.Linq;
using HahaFrame.Data.Core;

namespace HahaFrame.Data.Repository
{
    public partial interface IRepository<T> where T : BaseEntity
    {
        T GetById(object id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        IQueryable<T> Table { get; }
    }
}
