
using Microsoft.EntityFrameworkCore;
using Square.APIs;
using Square.Core.MiddleWares;
using Square.Core.RepositoryServices;
using Square.EFCore;
using Square.EFCore.Repositories;
using System.Net.Mail;
using System.Runtime;

namespace SquareAPIs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<ApplicationDBContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
  b => b.MigrationsAssembly(typeof(ApplicationDBContext).Assembly.FullName)
            ));

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
           builder.Services.AddScoped<ApplicationDBContext>();
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
            app.UseMiddleware<ProfilingMiddleWare>(); //To use my custom Middleware
            app.UseMiddleware<RequestLimitMiddleware>(150);
            app.MapControllers();

            app.Run();
        }
    }
}
