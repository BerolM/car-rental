using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Application.Infrastructure.Persistence
{
    public class CarRentalDbContext : DbContext, ICarRentalDbContext
    {
        public DbSet<ColorType> ColorType { get; set; }
        public DbSet<FuelType> FuelType { get; set; }
        public DbSet<RentalPeriod> RentalPeriod { get; set; }
        public DbSet<TireType> TireType { get; set; }
        public DbSet<TransmissionType> TransmissionType { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }
        public DbSet<VehicleBrand> VehicleBrand { get; set; }
        public DbSet<VehicleClassType> VehicleClassType { get; set; }
        public DbSet<VehicleModel> VehicleModel { get; set; }
        public DbSet<VehicleRentalPrice> VehicleRentalPrice { get; set; }
        public DbSet<VehicleImage> VehicleImage { get; set; }
        public DbSet<RentVehicle> RentVehicle { get; set; }

        public DbSet<User> User { get; set; }
        public DbSet<OperationClaim> OperationClaim { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaim { get; set; }

        private readonly string _connectionString;

        public CarRentalDbContext(DbContextOptions<CarRentalDbContext> options, IConfiguration configuration) : base(options)
        {
            _connectionString = configuration.GetConnectionString("CarRentalConnectionString");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                //string connectionString = "Server=.\\SQL2019DEV;Database=CarRental;Trusted_Connection=true;";
                base.OnConfiguring(optionsBuilder.UseSqlServer(_connectionString));
            }
        }
    }
}