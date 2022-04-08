using MovimaxNet.Models;

namespace MovimaxNet.Repositories;

internal class InMemoryFilmRepository : IFilmRepository
{
    public Task<bool> Add(Film data)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Film> Get(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Film>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<bool> Update(Film data)
    {
        throw new NotImplementedException();
    }
}