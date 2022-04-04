namespace MovimaxNet.Repositories;

public class RepositoryBuilder
{
    public IFilmRepository BuildFilmRepository()
    {
        return new InMemoryFilmRepository();
    }
    public IGenreRepository BuildGenreRepository()
    {
        return new InMemoryGenreRepository();
    }
}