using Microsoft.AspNetCore.Mvc;
using Shared_WebAPI.Movies.Services.Interfaces;
using System.Diagnostics;
using WebApp.Movies.Models;

namespace WebApp.Movies.Controllers
{
    public class MovieController : Controller
    {

       private readonly IWebApiMovieServiceClient _webApiMovieServiceClient;

        public MovieController(IWebApiMovieServiceClient webApiMovieServiceClient)
        {
            _webApiMovieServiceClient = webApiMovieServiceClient;
        }

        public IActionResult Movies()
        {
            var movies = _webApiMovieServiceClient.GetMovies();
            return View(movies);
        }

        
    }
}
