using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TCCCards.Models;

namespace TCCCards.Repository.Data
{
    public interface IDataContext
    {
        IQueryable<T> GetAll<T>()
            where T : BaseEntity;

        IQueryable<T> GetAllNoTracking<T>()
            where T : BaseEntity;

        IQueryable<T> GetAll<T>(Expression<Func<T, bool>> predicate)
            where T : BaseEntity;

        T GetById<T>(object id)
            where T : BaseEntity;

        void Insert<T>(T entity)
            where T : BaseEntity;

        void Update<T>(T entity)
            where T : BaseEntity;

        void Delete<T>(T entity)
             where T : BaseEntity;

        int Commit();

        string GetConnectionString();

        Task<int> CommitAsync();

        //DynamicQueryDataSourceResult RunQuery(DynamicQueryDataSourceRequest request);

        //List<T> GetFromProcedure<T>(string procName, params object[] args)
        //    where T : class;
    }
}
