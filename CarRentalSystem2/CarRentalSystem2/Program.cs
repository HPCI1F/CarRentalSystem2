using CarRentalSystem2.DataContext.Context;
using Microsoft.EntityFrameworkCore;

namespace CarRentalSystem2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            
            //builder.Services.AddDbContext<AppDbContext>(options =>
            //{
            //    options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CarRentalSystem2;Trusted_Connection=True;");
            //});

            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(
                    "Server=(localdb)\\mssqllocaldb;Database=CarRentalSystem2;Trusted_Connection=True;",
                    b => b.MigrationsAssembly("CarRentalSystem2.DataContext")
                );
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
