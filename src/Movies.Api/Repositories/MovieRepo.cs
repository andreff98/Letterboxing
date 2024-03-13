using Movies.Api.DAL;
using Movies.Api.Models;

namespace Movies.Api.Repositories;

public class MovieRepo(INeo4jDataAccess neo4JDataAccess, ILogger<MovieRepo> logger) : IMovieRepo
{
    public Task<Movie> CreateMovieAsync(Movie movie)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteMovieAsync(string movieId)
    {
        throw new NotImplementedException();
    }

    public async Task<Movie> GetMovieAsync(string movieId)
    {
        var query = "MATCH (m:Movie) RETURN m";

        var movies = await neo4JDataAccess.ExecuteReadScalarAsync<Movie>(query);

        return movies;
    }

    public async Task<List<Movie>> GetMoviesAsync()
    {
        var query = "MATCH (m:Movie) RETURN m";

        var movie = await neo4JDataAccess.ExecuteReadScalarAsync<Movie>(query);

        var movies = new List<Movie>() { movie };

        return movies;
    }

    public Task<Movie> UpdateMovieAsync(Movie movie)
    {
        throw new NotImplementedException();
    }
}