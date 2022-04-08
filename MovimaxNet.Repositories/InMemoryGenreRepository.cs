using MovimaxNet.Models;

namespace MovimaxNet.Repositories;

internal class InMemoryGenreRepository : IGenreRepository
{
    public Task<bool> Add(Genre data)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Genre> Get(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Genre>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<bool> Update(Genre data)
    {
        throw new NotImplementedException();
    }
} 