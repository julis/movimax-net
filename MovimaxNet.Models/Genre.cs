namespace MovimaxNet.Models;

public class Genre
{
    public int Id { get; set; }
    public string? Name { get; set; }

    public IList<FilmGenre>? FilmGenres { get; set; }
}