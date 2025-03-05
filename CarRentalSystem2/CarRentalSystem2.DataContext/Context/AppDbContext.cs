using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem2.DataContext.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }


        public DbSet<Car> Cars { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<RentalHistory> RentalHistorys { get; set; }
        //public DbSet<AbstractUser> AbstractUsers { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
        //public DbSet<AbstractRole> AbstractRoles { get; set; }
        public DbSet<CarRentalSystem> CarRentalSystems { get; set; }
        public DbSet<Clerk> Clerks { get; set; }
        public DbSet<NonRegisteredUser> NonRegisteredUsers { get; set; }
        public DbSet<RegisteredUser> RegisteredUsers { get; set; }
        public DbSet<RentalHistoryContainer> RentalHistoryContainers { get; set; }
        public DbSet<RentalsContainer> RentalsContainers { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CarRentalSystem2;Trusted_Connection=True;");
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Server=(localdb)\\mssqllocaldb;Database=CarRentalSystem2;Trusted_Connection=True;",
                    b => b.MigrationsAssembly("CarRentalSystem2.DataContext") // Migrations helyes assembly
                );
            }
        }
    }
}
