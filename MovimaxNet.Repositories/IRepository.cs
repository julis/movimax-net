using MovimaxNet.Models;

namespace MovimaxNet.Repositories;

public interface IRepository<T> where T : IModel 
{
    ICollection<T> GetAll();
    T Get(int id);
    void Add(T data);
    void Delete(int id);
    void Update(T data);
    
}