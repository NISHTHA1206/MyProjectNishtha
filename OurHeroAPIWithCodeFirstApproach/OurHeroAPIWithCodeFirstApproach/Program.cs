
using Microsoft.EntityFrameworkCore;
using OurHeroAPIWithCodeFirstApproach.Entity;
using OurHeroAPIWithCodeFirstApproach.Services;

namespace OurHeroAPIWithCodeFirstApproach
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<OurHeroDbContext>(db => db.UseSqlServer(builder.Configuration.GetConnectionString("ConStr")), ServiceLifetime.Singleton);
            builder.Services.AddTransient<IOurHeroService, OurHeroService>();
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
