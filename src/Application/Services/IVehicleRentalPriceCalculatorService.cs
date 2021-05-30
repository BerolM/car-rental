using Domain.DTOs;

namespace Application.Services
{
    public interface IVehicleRentalPriceCalculatorService
    {
        Response<VehicleRentalPriceCalculationResultDTO> Calculate(RentVehicleDTO rentVehicle);
    }
}
