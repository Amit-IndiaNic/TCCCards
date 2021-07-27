using System.Threading.Tasks;
using TCCCards.Repository.Data;

namespace TCCCards.Repository.Core
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDataContext _dataContext;
        public UnitOfWork(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public int Commit()
        {
            return _dataContext.Commit();
        }

        public Task<int> CommitAsync()
        {
            return _dataContext.CommitAsync();
        }
    }
}
