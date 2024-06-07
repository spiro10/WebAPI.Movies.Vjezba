using Shared_WebAPI.Movies.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Movies.Models.Dbo
{
    public class Movie : MovieBase
    {
        [Key]
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
    }
}
