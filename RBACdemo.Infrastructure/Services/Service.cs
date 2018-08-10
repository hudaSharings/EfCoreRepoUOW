using RBACdemo.Core.Repositories;
using RBACdemo.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace RBACdemo.Infrastructure.Services
{
    public class Service<T> : IService<T> where T : class
    {
        IRepository<T> _repository;
        public Service(IRepository<T> repository)
        {
            _repository = repository;
        }

        public void Add(T entity)
        {
            _repository.Add(entity);
        }

        public void AddandSave(T entity)
        {
            _repository.AddandSave(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _repository.AddRange(entities);
        }

        public void AddRangeandSave(IEnumerable<T> entities)
        {
            _repository.AddRangeandSave(entities);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
           return _repository.Find(predicate);
        }

        public T Get<Type>(Type id)
        {
           return _repository.Get(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public void Modify(T entity)
        {
            _repository.Modify(entity);
        }

        public void ModifyandSave(T entity)
        {
            _repository.ModifyandSave(entity);
        }

        public void Remove(T entity)
        {
            _repository.Remove(entity);
        }

        public void Remove<Type>(Type id)
        {
            _repository.Remove(id);
        }

        public void RemoveandSave(T entity)
        {
            _repository.RemoveandSave(entity);
        }

        public void RemoveandSave<Type>(Type id)
        {
            _repository.RemoveandSave(id);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _repository.RemoveRange(entities);
        }

        public void RemoveRangeandSave(IEnumerable<T> entities)
        {
            _repository.RemoveRangeandSave(entities);
        }

        public T SingleOrDefault(Expression<Func<T, bool>> predicate)
        {
            return _repository.SingleOrDefault(predicate);
        }
    }
}
