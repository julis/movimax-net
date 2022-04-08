using MovimaxNet.Repositories.EFCore;

namespace MovimaxNet.Repositories;

public class RepositoryService : IRepositoryService, IDisposable
{
    private readonly DatabaseContext _context;
    

    public RepositoryService(DatabaseContext context)
    {
        _context = context;
        FilmRepository = new FilmRepository(context);
    }

    public IFilmRepository FilmRepository { get; private set; }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}