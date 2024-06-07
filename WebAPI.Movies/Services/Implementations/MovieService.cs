using AutoMapper;
using Shared_WebAPI.Movies.Models.Binding;
using Shared_WebAPI.Movies.Models.ViewModel;
using WebAPI.Movies.Data;
using WebAPI.Movies.Models.Dbo;
using WebAPI.Movies.Services.Interfaces;

namespace WebAPI.Movies.Services.Implementations
{
    public class MovieService : IMovieService
    {
        private readonly ApplicationDbContext db;
        private readonly IMapper mapper;

        public MovieService(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }



        /// <summary>
        /// Gets all valid moview from db
        /// </summary>
        /// <returns></returns>
        public List<MovieViewModel> GetMovies()
        {
            var dbos = db.Movies.Where(x => !x.IsDeleted).ToList();
            return dbos.Select(x => mapper.Map<MovieViewModel>(x)).ToList();
        }

        /// <summary>
        /// Gets movie by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MovieViewModel GetMovie(int id)
        {
            var dbo = db.Movies.FirstOrDefault(x => x.Id == id);
            if (dbo == null)
            {
                return null;
            }
            return mapper.Map<MovieViewModel>(dbo);
        }

        /// <summary>
        /// Creates new movie
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MovieViewModel CreateMovie(MovieBinding model)
        {
            var dbo = mapper.Map<Movie>(model);
            db.Movies.Add(dbo);
            db.SaveChanges();
            return mapper.Map<MovieViewModel>(dbo);
        }

        /// <summary>
        /// Updates movie selected by model.id
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MovieViewModel EditMovie(MovieUpdateBinding model)
        {
            var dbo = db.Movies.FirstOrDefault(x => x.Id == model.Id);
            if (dbo == null)
            {
                return null;
            }
            mapper.Map(model, dbo);
            db.SaveChanges();
            return mapper.Map<MovieViewModel>(dbo);
        }

        /// <summary>
        /// Soft deletes movie by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MovieViewModel DeleteMovie(int id)
        {
            var dbo = db.Movies.FirstOrDefault(x => x.Id == id);
            if (dbo == null)
            {
                return null;
            }
            dbo.IsDeleted = true;
            db.SaveChanges();
            return mapper.Map<MovieViewModel>(dbo);

        }
    }
}
