namespace MovimaxNet.Models;

public class Genre : IModel
{
    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<Film> Films { get; set; }
}