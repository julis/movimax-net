using MovimaxNet.Models;

namespace MovimaxNet.Repositories;

public interface IRepository<T> where T : class 
{
    Task<IEnumerable<T>> GetAll();
    Task<T> Get(int id);
    Task<bool> Add(T data);
    Task<bool> Delete(int id);
    Task<bool> Update(T data);
    
}