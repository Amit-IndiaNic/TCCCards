using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TCCCards.Models;

namespace TCCCards.Repository.Data
{
    public class EFDataContext : DbContext, IDataContext
    {

        public EFDataContext(DbContextOptions options)
            : base(options)
        {
        }

        public int Commit()
        {
            return SaveChanges();
        }

        public Task<int> CommitAsync()
        {
            return SaveChangesAsync();
        }

        public void Delete<T>(T entity) where T : BaseEntity
        {
            Set<T>().Remove(entity);
        }

        public IQueryable<T> GetAll<T>()
            where T : BaseEntity
        {
            return Set<T>().AsQueryable();
        }

        public IQueryable<T> GetAllNoTracking<T>()
            where T : BaseEntity
        {
            return Set<T>().AsNoTracking();
        }

        public IQueryable<T> GetAll<T>(Expression<Func<T, bool>> predicate)
            where T : BaseEntity
        {
            return Set<T>().Where(predicate);
        }


        public T GetById<T>(object id)
            where T : BaseEntity
        {
            return Set<T>().Find(id);
        }

        public void Insert<T>(T entity) where T : BaseEntity
        {
            Set<T>().Add(entity);
        }

        void IDataContext.Update<T>(T entity)
        {
            Entry<T>(entity).State = EntityState.Modified;
        }

        public string GetConnectionString()
        {
            var con = Database.GetDbConnection();
            return con.ConnectionString;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //var typesToRegister = typeof(CardDetailsMap).Assembly.GetTypes().Where(s => s.Name.EndsWith("Map"));
            //foreach (var typeToRegister in typesToRegister)
            //{
            //    dynamic instance = Activator.CreateInstance(typeToRegister);
            //    modelBuilder.ApplyConfiguration(instance);
            //}
        }
    }
}
