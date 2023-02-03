using Host_Car.Models;
using Host_Car.Models.AdressModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Host_Car.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }


        public DbSet<Order> Orders { get; set; }
        public DbSet<PreOrderSearch> PreOrderSearchs { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Adress> Adresses { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<OficeTime> OficeTimes { get; set; }
        public DbSet<CarDetail> CarDetails { get; set; }
        public DbSet<CarBrand> CarBrands { get; set; }
        public DbSet<CarClass> CarClasses { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<CarPrice> CarPrices { get; set; }
        public DbSet<CarType> CarTypes { get; set; }
        public DbSet<FuelType> FuelTypes { get; set; }
        public DbSet<UserData> UserDatas { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
    }

}