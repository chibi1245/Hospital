﻿using Hospital.Model;
using Hospital.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Repositories.Implementation
{
    public class GenericRepository<T> : IDisposable, IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        internal DbSet<T> dbSet;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            dbSet = _context.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public async Task<T> AddAsync(T entity)
        {
            dbSet.Add(entity);
            return entity;
        }

        public void delete(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }

        public async Task<T> DeleteAsync(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
            return entity;
        }
        private bool disposed = false;

        public int StringSplitOption { get; private set; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                this.disposed = true;
            }
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null
            , Func<IQueryable<T>, IOrderedQueryable<T>>?orderBy = null,
            string includeProperties = " ")
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);

                }
                if (orderBy != null)
                {
                    return orderBy(query).ToList();
                }
                else
                {
                return query.ToList();
                }
            }
        

        public async Task<T> GetByAsync(object id)
        {
            return await dbSet.FindAsync(id);
        }

        public T GetById(object id)
        {
            ;
            return dbSet.Find(id);
        }

        public void Update(T entity)
        {
            dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public void Delete(HospitalInfo model)
        {
            throw new NotImplementedException();
        }

        public void Delete(Contact model)
        {
            throw new NotImplementedException();
        }

        public void Delete(Room model)
        {
            throw new NotImplementedException();
        }

        public void Delete(Timing model)
        {
            throw new NotImplementedException();
        }
    }
}
