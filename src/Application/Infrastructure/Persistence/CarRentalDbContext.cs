using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Application.Infrastructure.Persistence
{
    public class CarRentalDbContext:DbContext
    {
        public DbSet<ColorType> ColorTypes { get; set; }
        public DbSet<FuelType> FuelTypes { get; set; }
        public DbSet<RentalPeriod> RentalPeriods { get; set; }
        public DbSet<TireType> TireTypes { get; set; }
        public DbSet<TransmissionType> TransmissionTypes { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleBrand> VehicleBrands { get; set; }
        public DbSet<VehicleClassType> VehicleClassTypes { get; set; }
        public DbSet<VehicleModel> VehicleModels { get; set; }
        public DbSet<VehicleRentalPrice> VehicleRentalPrices { get; set; }

        public readonly string _connectionString;
        public CarRentalDbContext(DbContextOptions<CarRentalDbContext> options,IConfiguration configuration) : base(options)
        {
            _connectionString = configuration.GetConnectionString("CarRentalConnectionString");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured==false)
            {
                //string connectionString = "Server=LAPTOP-UMEMPA7A;Database=CarRental;Trusted_Connection=true;";
                base.OnConfiguring(optionsBuilder.UseSqlServer(_connectionString));
            }


         }

    }
}
