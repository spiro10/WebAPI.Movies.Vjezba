using Shared_WebAPI.Movies.Models.Binding;
using Shared_WebAPI.Movies.Models.ViewModel;
using Shared_WebAPI.Movies.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared_WebAPI.Movies.Services.Implemenations
{
    public class WebApiMovieServiceClient : WebApiServiceClientBase, IWebApiMovieServiceClient
    {
        public WebApiMovieServiceClient(HttpClient httpClient, Action<HttpResponseMessage> unsuccessfulResponseAction) : base(httpClient, unsuccessfulResponseAction)
        {
        }
        /// <summary>
        /// Gets a movie by its id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="unsuccessfulResponseAction"></param>
        /// <returns></returns>
        public MovieViewModel GetMovie(long id, Action<HttpResponseMessage> unsuccessfulResponseAction = null)
        {
            return DoRequestAndTryGetResponseContent<MovieViewModel>($"api/movie/{id}", HttpMethod.Get, true, unsuccessfulResponseAction);
        }

        /// <summary>
        /// Gets a movie by its id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <param name="unsuccessfulResponseAction"></param>
        /// <returns></returns>
        public T GetMovie<T>(long id, Action<HttpResponseMessage> unsuccessfulResponseAction = null)
        {
            return DoRequestAndTryGetResponseContent<T>($"api/movie/{id}", HttpMethod.Get, true, unsuccessfulResponseAction);
        }

        /// <summary>
        /// Adds a movie to the database
        /// </summary>
        /// <param name="model"></param>
        /// <param name="unsuccessfulResponseAction"></param>
        /// <returns></returns>
        public MovieViewModel AddMovie(MovieBinding model, Action<HttpResponseMessage> unsuccessfulResponseAction = null)
        {
            return DoRequestAndTryGetResponseContent<MovieViewModel>("api/movie", HttpMethod.Post, true, unsuccessfulResponseAction, model);
        }

        /// <summary>
        /// Updates a movie in the database
        /// </summary>
        /// <param name="model"></param>
        /// <param name="unsuccessfulResponseAction"></param>
        /// <returns></returns>
        public MovieViewModel UpdateMovie(MovieUpdateBinding model, Action<HttpResponseMessage> unsuccessfulResponseAction = null)
        {
            return DoRequestAndTryGetResponseContent<MovieViewModel>("api/movie", HttpMethod.Put, true, unsuccessfulResponseAction, model);
        }


        /// <summary>
        ///  Get all movies
        /// </summary>
        /// <param name="unsuccessfulResponseAction"></param>
        /// <returns></returns>
        public List<MovieViewModel> GetMovies(Action<HttpResponseMessage> unsuccessfulResponseAction = null)
        {
            return DoRequestAndTryGetResponseContent<List<MovieViewModel>>($"api/movie/movies", HttpMethod.Get, true, unsuccessfulResponseAction);
        }

        public MovieViewModel DeleteMovie(long id, Action<HttpResponseMessage> unsuccessfulResponseAction = null)
        {
            return DoRequestAndTryGetResponseContent<MovieViewModel>($"api/movie/{id}", HttpMethod.Delete, true, unsuccessfulResponseAction);
        }
    }
}
