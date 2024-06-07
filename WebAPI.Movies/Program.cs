
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WebAPI.Movies.Data;
using WebAPI.Movies.Mapping;
using WebAPI.Movies.Services.Implementations;
using WebAPI.Movies.Services.Interfaces;

namespace WebAPI.Movies
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var defaultConnection = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string \"DefaultConnection\" not found");
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(defaultConnection));
            // Add services to the container.

            builder.Services.AddAutoMapper(typeof(MappingProfile));
            builder.Services.AddScoped<IMovieService, MovieService>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
