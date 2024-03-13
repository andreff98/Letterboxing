using Movies.Api.Models;

namespace Movies.Api.Repositories;

public interface IMovieRepo
{
    Task<List<Movie>> GetMoviesAsync();
    Task<Movie> GetMovieAsync(string movieId);
    Task<Movie> CreateMovieAsync(Movie movie);
    Task<Movie> UpdateMovieAsync(Movie movie);
    Task<bool> DeleteMovieAsync(string movieId);
}