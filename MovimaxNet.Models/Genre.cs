namespace MovimaxNet.Models;

public class Genre : IModel
{
    public int Id { get; set; }
    public string? Name { get; set; }

    public IList<FilmGenre>? FilmGenres { get; set; }
}