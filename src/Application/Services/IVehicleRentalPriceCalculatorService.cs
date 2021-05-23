using Domain.DTOs;

namespace Application.Services
{
    public interface IVehicleRentalPriceCalculatorService
    {
        Response<decimal> Calculate(RentVehicleDTO rentVehicle);
    }
}
