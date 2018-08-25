using System;
using System.Collections.Generic;
using System.Linq;
using AIBot.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace AIBot.Core.Infrastructure
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly AIBotDbContext context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;
        public Repository(AIBotDbContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }
        public T Get(int id)
        {
            return entities.SingleOrDefault(s => s.Id == id);
        }
        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }
        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.SaveChanges();
        }
        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }

        public T Get(long id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> TableAsNoTracking => context.Set<T>().AsNoTracking();
        public IQueryable<T> Table => context.Set<T>();
    }
}
