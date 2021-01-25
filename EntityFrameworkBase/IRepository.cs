﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace EntityFrameworkBase
{
    public interface IRepository<TEntity, TKey> where TEntity : class
    {
        string TableName { get; }

        IEnumerable<TEntity> GetAll();

        TEntity Get(TKey id);

        IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> predicate);

        TEntity Update(TEntity entity);

        void Add(TEntity entity);

        void Remove(TEntity entity);

        void SaveChange();
    }
}
