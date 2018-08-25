using System.Collections.Generic;
using AIBot.Core.Domain;

namespace AIBot.Core.Infrastructure
{
    public interface IRepository<T> where T : Entity
    {
        IEnumerable<T> GetAll();
        T Get(long id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
