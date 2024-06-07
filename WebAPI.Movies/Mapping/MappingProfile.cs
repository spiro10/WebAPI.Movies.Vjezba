using AutoMapper;
using Shared_WebAPI.Movies.Models.Binding;
using Shared_WebAPI.Movies.Models.ViewModel;
using WebAPI.Movies.Models.Dbo;

namespace WebAPI.Movies.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Movie, MovieViewModel>();
            CreateMap<MovieUpdateBinding, Movie>();
            CreateMap<MovieBinding, Movie>();
        }
    }
}
