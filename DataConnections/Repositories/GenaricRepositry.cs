using Application.Contract.Presistence;
using DataConnections.Data;
using Microsoft.EntityFrameworkCore;
using Shop.ModelArea.Models.Commen;

using System.Linq.Expressions;


namespace DataConnections.Repositories
{
    public class GenaricRepositry<T> : IGenaricRepositry<T> where T : BaseModel
    {
        protected readonly ApplicationContext _context;

        public GenaricRepositry(ApplicationContext context)
        {
            _context = context;
        }

        public async Task Create(T entity)
        {
            await _context.AddAsync(entity);
        }

        public async Task Delete(T entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> Get(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid Id)
        {
            return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == Id);
        }

        public Task<bool> IsRecordExsits(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate).AnyAsync();
        }

        public IEnumerable<T> Query(Expression<Func<T, bool>> predicate)
        {
            var entities = _context.Set<T>().Where(predicate).ToList();
            return entities;
        }

        public IEnumerable<T> Query()
        {
            var entities = _context.Set<T>().AsNoTracking().ToList();
            return entities;
        }
    }
}
