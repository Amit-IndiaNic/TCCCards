using System.Threading.Tasks;

namespace TCCCards.Repository.Core
{
    public interface IUnitOfWork
    {
        int Commit();
        Task<int> CommitAsync();
    }
}
