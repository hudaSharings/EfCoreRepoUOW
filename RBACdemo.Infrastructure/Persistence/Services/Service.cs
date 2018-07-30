using RBACdemo.Core.Repositories;
using RBACdemo.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace RBACdemo.Infrastructure.Persistence.Services
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

        public void AddRange(IEnumerable<T> entities)
        {
            _repository.AddRange(entities);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
           return _repository.Find(predicate);
        }

        public T Get(int id)
        {
           return _repository.Get(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public void Remove(T entity)
        {
            _repository.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _repository.RemoveRange(entities);
        }

        public T SingleOrDefault(Expression<Func<T, bool>> predicate)
        {
            return _repository.SingleOrDefault(predicate);
        }
    }
}
