using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TCCCards.Models;

namespace TCCCards.Repository.Core
{
    public interface IBaseRepository<T>
        where T : BaseEntity
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetAllNoTracking();
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate);
        T GetById(object id);
        T GetByPredicate(Expression<Func<T, bool>> predicate);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        //List<T> GetFromProcedure(string procName, params object[] args);
        //Task<T> WithConnection<T>(Func<IDbConnection, Task<T>> getData);
    }

    //public interface IAuditableBaseRepository<T> : IBaseRepository<T>
    //    where T : BaseEntity
    //{
    //    void InsertWithAudit(T entity, CoreAuditEntity auditDetails);
    //    void UpdateAudit<TM>(TM entity, TM newEntity, CoreAuditEntity auditDetails);
    //}
}
