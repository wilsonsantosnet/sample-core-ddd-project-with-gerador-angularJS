﻿using Common.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Common.Domain.Interfaces
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(params Expression<Func<T, object>>[] includes);
        T Add(T entity);
        T Update(T entity);
        void Remove(T entity);
        Task<PaginateResult<T>> PagingAndDefineFields(FilterBase filters, IQueryable<T> queryFilter);

        Task<List<T2>> ToListAsync<T2>(IQueryable<T2> source);
        Task<int> CountAsync<T2>(IQueryable<T2> source);
        Task<decimal> SumAsync<T2>(IQueryable<T2> source, Expression<Func<T2, decimal>> selector);
        Task<T2> SingleOrDefaultAsync<T2>(IQueryable<T2> source);
        Task<T2> FirstOrDefaultAsync<T2>(IQueryable<T2> source);
        Task<int> CommitAsync();

    }
}
