using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared_WebAPI.Movies.Services.Implemenations
{
    public static class WebApiServiceClientCollectionExtension
    {
        public static IServiceCollection AddWebApiMovieServiceClient(this IServiceCollection services, string webApiServiceBaseUrl, Action<HttpResponseMessage> unsuccessfulResponseAction = null)
        {
            services.AddHttpClient(nameof(WebApiMovieServiceClient)).AddTypedClient<IWebApiMovieServiceClient>
        }
    }
}
