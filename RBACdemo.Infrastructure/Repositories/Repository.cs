﻿using Microsoft.EntityFrameworkCore;
using RBACdemo.Core.Persistence;
using RBACdemo.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace RBACdemo.Infrastructure.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

        public Repository(IContextFactory context)
        {
            Context = context.DbContext;
        }
        public TEntity Get<Type>(Type id)
        {
            return Context.Set<TEntity>().Find(id);
        }
        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }
        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().SingleOrDefault(predicate);
        }
        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }
        public void AddandSave(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
            Save();
            
        }
        public void AddRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().AddRange(entities);
            Save();
        }
        public void AddRangeandSave(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().AddRange(entities);
            Save();
        }
        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }
        public void RemoveandSave(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
            Save();
        }
        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
        }
        public void RemoveRangeandSave(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
            Save();
        }
        public void Modify(TEntity entity)
        {
            Context.Entry<TEntity>(entity).State = EntityState.Modified;
        }

        public void ModifyandSave(TEntity entity)
        {
            Context.Entry<TEntity>(entity).State = EntityState.Modified;
            Save();
        }
        public void Save()
        {
            Context.SaveChanges();
        }

        public void Remove<Type>(Type id)
        {
            Remove(Get(id));
        }

        public void RemoveandSave<Type>(Type id)
        {
            RemoveandSave(Get(id));
        }
    }
}
