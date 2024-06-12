using Shared_WebAPI.Movies.Models.Binding;
using Shared_WebAPI.Movies.Models.ViewModel;

namespace Shared_WebAPI.Movies.Services.Interfaces
{
    public interface IWebApiMovieServiceClient
    {
        MovieViewModel AddMovie(MovieBinding model, Action<HttpResponseMessage> unsuccessfulResponseAction = null);
        MovieViewModel DeleteMovie(long id, Action<HttpResponseMessage> unsuccessfulResponseAction = null);
        MovieViewModel GetMovie(long id, Action<HttpResponseMessage> unsuccessfulResponseAction = null);
        T GetMovie<T>(long id, Action<HttpResponseMessage> unsuccessfulResponseAction = null);
        List<MovieViewModel> GetMovies(Action<HttpResponseMessage> unsuccessfulResponseAction = null);
        MovieViewModel UpdateMovie(MovieUpdateBinding model, Action<HttpResponseMessage> unsuccessfulResponseAction = null);
    }
}