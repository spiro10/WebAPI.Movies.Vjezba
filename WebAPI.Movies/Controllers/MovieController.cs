using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared_WebAPI.Movies.Models.Binding;
using Shared_WebAPI.Movies.Models.ViewModel;
using WebAPI.Movies.Services.Interfaces;

namespace WebAPI.Movies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;

        public MovieController(IMovieService movieService, IMapper mapper)
        {
            _movieService = movieService;
            _mapper = mapper;
        }

        /// <summary>
        /// Adds movie to database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(MovieViewModel), StatusCodes.Status200OK)]
        public ActionResult<MovieViewModel> Add(MovieBinding model)
        {
            var movie = _movieService.CreateMovie(model);
            return Ok(movie);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(MovieViewModel), 200)]
        public ActionResult<MovieViewModel> Get(int id)
        {
            var movie = _movieService.GetMovie(id);
            return Ok(movie);
        }

        [HttpGet("Movies")]
        [ProducesResponseType(typeof(MovieViewModel),200)]
        public ActionResult<List<MovieViewModel>> GetMovies()
        {
            var movies = _movieService.GetMovies();
            return Ok(movies);
        }

        [HttpPut]
        [ProducesResponseType(typeof(MovieViewModel), 200)]
        public ActionResult<MovieViewModel> Edit(MovieUpdateBinding model)
        {
            var movie = _movieService.EditMovie(model);
            return Ok(movie);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(MovieViewModel), 200)]
        public ActionResult<MovieViewModel> Delete(int id)
        {
            var movie = _movieService.DeleteMovie(id);
            return Ok(movie);
        }
    }
}
