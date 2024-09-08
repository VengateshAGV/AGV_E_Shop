

using Shop.ModelArea.Models.Commen;
using System.Linq.Expressions;

namespace Application.Contract.Presistence
{
    public interface IGenaricRepositry<T> where T : BaseModel
    {
        Task Create(T entity);

        Task Delete(T entity);

        Task<List<T>> Get(Expression<Func<T, bool>> predicate);

        Task<List<T>> GetAllAsync();

        IEnumerable<T> Query(Expression<Func<T, bool>> predicate);

        IEnumerable<T> Query();

        Task<T> GetByIdAsync(Guid Id);

        Task<bool> IsRecordExsits(Expression<Func<T, bool>> predicate);
    }
}
