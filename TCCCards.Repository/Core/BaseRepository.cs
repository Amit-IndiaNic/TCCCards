using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TCCCards.Models;
using TCCCards.Repository.Data;

namespace TCCCards.Repository.Core
{
    public class BaseRepository<T> : IBaseRepository<T>
        where T : BaseEntity
    {
        protected readonly IDataContext _dataContext;
        public readonly string _connectionString;
        public BaseRepository(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IDbConnection Connection
        {
            get
            {
                var constr = _dataContext.GetConnectionString();
                return new SqlConnection(constr);
            }
        }

        public virtual void Delete(T entity)
        {
            _dataContext.Delete(entity);
        }

        public virtual IQueryable<T> GetAll()
        {
            return _dataContext.GetAll<T>();
        }

        public virtual IQueryable<T> GetAllNoTracking()
        {
            return _dataContext.GetAllNoTracking<T>();
        }

        public virtual IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return _dataContext.GetAll(predicate);
        }

        public virtual T GetById(object id)
        {
            return _dataContext.GetById<T>(id);
        }

        public T GetByPredicate(Expression<Func<T, bool>> predicate)
        {
            return _dataContext.GetAll(predicate).FirstOrDefault();
        }

        public virtual void Insert(T entity)
        {
            _dataContext.Insert(entity);
        }

        public virtual void Update(T entity)
        {
            _dataContext.Update(entity);
        }

    }
}
