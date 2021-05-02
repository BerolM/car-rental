using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Infrastructure.Persistence
{
    public interface ICarRentalDbContext
    {
        DbSet<ColorType> ColorType { get; set; }
        DbSet<FuelType> FuelType { get; set; }
        DbSet<RentalPeriod> RentalPeriod { get; set; }
        DbSet<TireType> TireType { get; set; }
        DbSet<TransmissionType> TransmissionType { get; set; }
        DbSet<Vehicle> Vehicle { get; set; }
        DbSet<VehicleBrand> VehicleBrand { get; set; }
        DbSet<VehicleClassType> VehicleClassType { get; set; }
        DbSet<VehicleModel> VehicleModel { get; set; }
        DbSet<VehicleRentalPrice> VehicleRentalPrice { get; set; }
        DbSet<VehicleImage> VehicleImage { get; set; }

        int SaveChanges();
    }
}