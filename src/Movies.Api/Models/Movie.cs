namespace Movies.Api.Models;

public class Movie
{
    public int? Id { get; set; }
    public int? Released { get; set; }
    public string? Tagline { get; set; }
    public string? Title { get; set; }
}