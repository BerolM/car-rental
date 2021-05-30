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
        DbSet<RentVehicle> RentVehicle { get; set; }

        DbSet<User> User { get; set; }
        DbSet<OperationClaim> OperationClaim { get; set; }
        DbSet<UserOperationClaim> UserOperationClaim { get; set; }

        int SaveChanges();
    }
}