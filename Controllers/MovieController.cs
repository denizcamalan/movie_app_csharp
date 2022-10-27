using movie_api.Interface;
using movie_api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace movie_api.Controllers
{
    [Route("movie_archive")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovies _IMovie;

        public MoviesController(IMovies IMovie)
        {
            _IMovie = IMovie;
        }

        // GET movie_archive/list
        [AllowAnonymous]
        [Route("/list")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Movies>>> Get()
        {
            if (_IMovie == null)
                return BadRequest();
            return Ok(await Task.FromResult(_IMovie.ListMovies()));
        }

        // GET movie_archive/get/id
        [Authorize]
        [Route("/get/{id}")]
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Movies>> Get(int id)
        {
            var Movies = await Task.FromResult(_IMovie.GetMoviesById(id));
            if (Movies == null)
                return NotFound();
            return Ok(Movies);
        }

        // POST movie_archive/add
        [Authorize]
        [Route("/add")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Movies>> Post(Movies Movies)
        {
            _IMovie.AddMovie(Movies);
            if (Movies == null)
                return BadRequest();
            return Created("",await Task.FromResult(Movies));
        }

        // PUT movie_archive/update/id
        [Authorize]
        [Route("/update/{id}")]
        [HttpPut()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Movies>> Put(int id, Movies Movies)
        {
            if (id != Movies.Id)
            {
                return BadRequest();
            }
            try
            {
                _IMovie.UpdateMovie(Movies);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MoviesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok(await Task.FromResult(Movies));
        }

        // DELETE movie_archive/delete/id
        [Authorize]
        [Route("/delete/{id}")]
        [HttpDelete()]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Movies>> Delete(int id)
        {
            if (!MoviesExists(id))
                return NotFound();
            var Movies = _IMovie.DeleteMovie(id);
            return Ok( await Task.FromResult(Movies));
        }

        private bool MoviesExists(int id)
        {
            return _IMovie.CheckMovie(id);
        }
    }
}