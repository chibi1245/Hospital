using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Repositories.Interface
{
    public interface IGenericRepository <T>:IDisposable
    {
        IEnumerable<T> GetAll(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T> ,IOrderedQueryable <T>> orderBy =null,

            string includeProperties="");
        T GetById(object id);
        Task<T> GetByAsync(object id);
        void Add( T entity);

        Task<T> AddAsync(T entity);
        void Update(T entity);
        Task<T>  UpdateAsync (T entity);
        void delete( T entity);
        Task<T>  DeleteAsync(T entity);
        void Delete(HospitalInfo model);
        void Delete(Contact model);
        void Delete(Room model);
        void Delete(Timing model);
    }
}
