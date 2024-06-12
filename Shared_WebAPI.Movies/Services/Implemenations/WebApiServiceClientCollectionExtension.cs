using Microsoft.Extensions.DependencyInjection;
using Shared_WebAPI.Movies.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Shared_WebAPI.Movies.Services.Implemenations
{
    public static class WebApiServiceClientCollectionExtension
    {
        public static IServiceCollection AddWebApiMovieServiceClient(this IServiceCollection services, string webApiServiceBaseUrl, Action<HttpResponseMessage> unsuccessfulResponseAction = null)
        {
            //Potrebno je instalirat pckg Microsoft.Extensions.Http
            services.AddHttpClient(nameof(WebApiMovieServiceClient)).AddTypedClient<IWebApiMovieServiceClient>(c => new WebApiMovieServiceClient(c, unsuccessfulResponseAction))
                .ConfigureHttpClient(c =>
                {
                    c.BaseAddress = new Uri(webApiServiceBaseUrl);
                });

            return services;
        }

        /// <summary>
        /// Primjer, ne poziva se nigdje!!
        /// </summary>
        /// <param name="services"></param>
        /// <param name="webApiServiceBaseUrl"></param>
        /// <param name="unsuccessfulResponseAction"></param>
        /// <returns></returns>
        //public static IServiceCollection AddWebApiFiscalizationServiceClient(this IServiceCollection services, string webApiServiceBaseUrl, Action<HttpResponseMessage> unsuccessfulResponseAction = null)
        //{
        //    //Potrebno je instalirat pckg Microsoft.Extensions.Http
        //    services.AddHttpClient(nameof(WebApiFiscalizationServiceClient)).AddTypedClient<IWebApiFiscalizationServiceClient>(c => new WebApiFiscalizationServiceClient(c, unsuccessfulResponseAction))
        //        .ConfigureHttpClient(c =>
        //        {
        //            c.BaseAddress = new Uri(webApiServiceBaseUrl);
        //        });

        //    return services;
        //}
    }
}
