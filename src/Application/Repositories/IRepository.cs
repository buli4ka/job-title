using Domain.Common;

namespace Application.Repositories;

public interface IRepository<T> where T : BaseEntity
{
    Task<IEnumerable<T>> GetAll();
    Task<T> Create(T entity);
    Task<T> GetById(Guid id);
    Task Update(T entity);
    Task DeleteById(Guid id);
}