using Microsoft.EntityFrameworkCore;
using MyTasker.Core.Models;
using System.Linq.Expressions;

namespace MyTasker.API.Repositories.Abstract.Common
{
    public interface IGenericRepository<T> where T : BaseModel
    {
        DbSet<T> Table {  get; }
        Task<int> SaveAsync();
        int Save();
        Task<List<T>?> GetAllAsync();
        Task<List<T>?> GetAllAsync(Expression<Func<T,bool>>filter);
        Task<T?> GetSingleAsync(Expression<Func<T,bool>>filter);
        Task<int> GetCountAsync();
        Task<int> GetCountAsync(Expression<Func<T, bool>> filter);

        Task<bool> InsertAsync(T item);
        Task<bool> UpdateAsync(T item);
        Task<bool> RemoveAsync(int id);
        Task<bool> RemoveRangeAsync(List<int> ids);
    }
}
