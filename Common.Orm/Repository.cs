﻿using Common.Domain.Base;
using Common.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Common.Orm
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {

        protected DbContext ctx;
        protected DbSet<T> dbSet;

        public Repository(DbContext ctx)
        {
            this.ctx = ctx;
            this.dbSet = this.ctx.Set<T>();
        }

        public virtual IQueryable<T> GetAll()
        {
            return this.dbSet.AsNoTracking();
        }

        public virtual IQueryable<T> GetAll(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = ctx.Set<T>();
            return includes.Aggregate(query, (current, include) => current.Include(include))
                .AsNoTracking();
        }

        public virtual T Add(T entity)
        {
            var result = this.dbSet.Add(entity);
            return result.Entity;
        }

        public virtual T Update(T entity)
        {
            var entry = this.ctx.Entry(entity);
            this.dbSet.Attach(entity);
            entry.State = EntityState.Modified;

            return entity;
        }

        public virtual void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public virtual async Task<PaginateResult<T>> PagingAndDefineFields(FilterBase filters, IQueryable<T> queryFilter)
        {
            var queryOptimize = this.DefineFieldsGetByFilters(queryFilter, filters);

            var totalCount = await this.CountAsync(queryFilter);
            var paginateResult = await this.ToListAsync(this.Paging(queryOptimize, filters, totalCount));
            var queryMapped = this.MapperGetByFiltersToDomainFields(queryFilter, paginateResult, filters.QueryOptimizerBehavior);

            return new PaginateResult<T>
            {
                TotalCount = totalCount,
                ResultPaginatedData = queryMapped,
                Source = queryFilter
            };
        }

        protected abstract dynamic DefineFieldsGetOne(IQueryable<T> source, string queryOptimizerBehavior);

        protected abstract IQueryable<dynamic> DefineFieldsGetByFilters(IQueryable<T> source, FilterBase filters);

        protected abstract IQueryable<T> MapperGetByFiltersToDomainFields(IQueryable<T> source, IEnumerable<dynamic> result, string queryOptimizerBehavior);

        protected abstract T MapperGetOneToDomainFields(IQueryable<T> source, dynamic result, string queryOptimizerBehavior);

        protected virtual T GetAndDefineFields(IQueryable<T> source, string queryOptimizerBehavior)
        {
            var queryOptimize = this.DefineFieldsGetOne(source, queryOptimizerBehavior);
            var queryMapped = this.MapperGetOneToDomainFields(source, queryOptimize, queryOptimizerBehavior);
            return queryMapped;
        }

        protected Expression<Func<T, object>>[] DataAgregation(FilterBase filter)
        {
            return DataAgregation(new Expression<Func<T, object>>[] { }, filter);
        }

        protected virtual Expression<Func<T, object>>[] DataAgregation(Expression<Func<T, object>>[] includes, FilterBase filter)
        {
            return includes;
        }


        #region async

        public Task<List<T2>> ToListAsync<T2>(IQueryable<T2> source)
        {
            return source.ToListAsync();
        }

        public Task<T2> SingleOrDefaultAsync<T2>(IQueryable<T2> source)
        {
            return source.SingleOrDefaultAsync();
        }

        public Task<T2> FirstOrDefaultAsync<T2>(IQueryable<T2> source)
        {
            return source.FirstOrDefaultAsync<T2>();
        }

        public Task<int> CountAsync<T2>(IQueryable<T2> source)
        {
            return source.CountAsync();
        }

        public Task<decimal> SumAsync<T2>(IQueryable<T2> source, Expression<Func<T2, decimal>> selector)
        {
            return source.SumAsync(selector);
        }


        public Task<int> CommitAsync()
        {
            return this.ctx.SaveChangesAsync();
        }

        #endregion

        #region helpers

        private Boolean IsAttached(T entity)
        {
            return ((from item in this.dbSet
                     where item == entity
                     select item).Count() > 0);
        }


        private IQueryable<T2> Paging<T2>(IQueryable<T2> source, FilterBase filter, int totalCount)
        {
            if (filter.IsPagination)
            {
                var pageIndex = filter.PageIndex.IsMoreThanZero() ? filter.PageIndex - 1 : 0;
                var pageSize = filter.PageSize;
                var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

                return source.Skip(filter.PageSkipped).Take(pageSize);
            }

            return source;

        }



        #endregion


    }

}
