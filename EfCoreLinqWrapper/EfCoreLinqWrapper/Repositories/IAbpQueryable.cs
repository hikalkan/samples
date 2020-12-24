using System.Linq;
using System.Threading.Tasks;

namespace EfCoreLinqWrapper.Repositories
{
    public interface IAbpQueryable<T> : IQueryable<T>
    {
        Task BeginTransactionAsync();
    }
}
