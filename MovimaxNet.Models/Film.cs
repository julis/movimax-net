namespace MovimaxNet.Models;

public class Film
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public DateTime ReleaseDate { get; set; }
    public uint RuntimeMinute { get; set; }
    public string? Revenue { get; set; }
    public string? PosterUrl { get; set; }
    public IList<FilmGenre>? FilmGenres { get; set; }
}