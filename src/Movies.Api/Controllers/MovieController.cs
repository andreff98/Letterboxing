using Microsoft.AspNetCore.Mvc;
using Movies.Api.Models;
using Movies.Api.Repositories;

namespace Movies.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MovieController(ILogger<MovieController> logger, IMovieRepo movieRepo) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetMovies()
    {
        var movies = await movieRepo.GetMoviesAsync();

        return Ok(movies);
    }

    [HttpGet("{movieId}")]
    public async Task<IActionResult> GetMovie(string movieId)
    {
        var movie = await movieRepo.GetMovieAsync(movieId);

        return Ok(movie);
    }

    [HttpPost]
    public async Task<IActionResult> CreateMovie([FromBody] Movie movie)
    {
        var newMovie = await movieRepo.CreateMovieAsync(movie);

        return CreatedAtRoute("GetMovie", new { movieId = newMovie.Id }, newMovie);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateMovie([FromBody] Movie movie)
    {
        var updatedMovie = await movieRepo.UpdateMovieAsync(movie);

        return Ok(updatedMovie);
    }

    [HttpDelete("{movieId}")]
    public async Task<IActionResult> DeleteMovie(string movieId)
    {
        var result = await movieRepo.DeleteMovieAsync(movieId);

        return result ? Ok() : StatusCode(StatusCodes.Status500InternalServerError);
    }
}