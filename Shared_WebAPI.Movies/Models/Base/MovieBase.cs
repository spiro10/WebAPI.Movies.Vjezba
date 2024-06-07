using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared_WebAPI.Movies.Models.Base
{
    public abstract class MovieBase
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int ReleaseDate { get; set; }
    }
}
