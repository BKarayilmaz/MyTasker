using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MyTasker.API.Context;
using MyTasker.API.Repositories.Abstract.Common;
using MyTasker.Core.Models;
using System.Linq.Expressions;

namespace MyTasker.API.Repositories.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseModel
    {
        private readonly MyTaskerContext _context;

        public GenericRepository(MyTaskerContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<List<T>?> GetAllAsync()=> await Table.AsNoTracking().ToListAsync();

        public async Task<List<T>?> GetAllAsync(Expression<Func<T, bool>> filter) => await Table.AsNoTracking().Where(filter).ToListAsync();

        public async Task<int> GetCountAsync() => await Table.CountAsync();

        public async Task<int> GetCountAsync(Expression<Func<T, bool>> filter) => await Table.CountAsync(filter);

        public async Task<T?> GetSingleAsync(Expression<Func<T, bool>> filter) => await Table.FirstOrDefaultAsync(filter);

        public async Task<bool> InsertAsync(T item)
        {
            try
            {
                EntityEntry<T> entityEntry = await Table.AddAsync(item);
                await SaveAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> RemoveAsync(int id)
        {
            try
            {
                var model = await Table.FirstOrDefaultAsync(x => x.Id == id);
                Table.Remove(model);
                await SaveAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> RemoveRangeAsync(List<int> ids)
        {
            try
            {
                var model = await Table.AsNoTracking().Where(x => ids.Contains(x.Id)).ToListAsync();
                Table.RemoveRange(model);
                await SaveAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public async Task<int> SaveAsync()=>await _context.SaveChangesAsync();

        public async Task<bool> UpdateAsync(T item)
        {
            try
            {
                EntityEntry<T> entityEntry = Table.Update(item);
                await SaveAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
