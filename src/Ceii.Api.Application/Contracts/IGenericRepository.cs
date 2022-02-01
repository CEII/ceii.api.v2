namespace Ceii.Api.Application.Contracts;

public interface IGenericRepository<T> where T : class
{
    Task<IList<T>> GetAll();

    Task<T> GetById(object id);

    Task<T> Insert(T t);

    Task<T> Delete(object id);

    Task<T> Update(T t);
}