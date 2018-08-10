using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace RBACdemo.Core.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get<Type>(Type id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity entity);
        void AddandSave(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void AddRangeandSave(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveandSave(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        void RemoveRangeandSave(IEnumerable<TEntity> entities);
        void Modify(TEntity entity);
        void ModifyandSave(TEntity entity);

        void Remove<Type>(Type id);
        void RemoveandSave<Type>(Type id); 
        void Save();
    }
}
