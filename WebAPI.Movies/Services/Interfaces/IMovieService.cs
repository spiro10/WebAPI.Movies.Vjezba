using Shared_WebAPI.Movies.Models.Binding;
using Shared_WebAPI.Movies.Models.ViewModel;

namespace WebAPI.Movies.Services.Interfaces
{
    public interface IMovieService
    {
        MovieViewModel CreateMovie(MovieBinding model);
        MovieViewModel DeleteMovie(int id);
        MovieViewModel EditMovie(MovieUpdateBinding model);
        MovieViewModel GetMovie(int id);
        List<MovieViewModel> GetMovies();
    }
}