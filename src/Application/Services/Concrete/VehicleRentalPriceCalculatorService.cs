using Domain.Constants;
using Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Concrete
{
    public class VehicleRentalPriceCalculatorService : IVehicleRentalPriceCalculatorService
    {
        private IVehicleRentalPriceService VehicleRentalPriceService { get;}
        private IRentVehicleService RentVehicleService { get; }
        public VehicleRentalPriceCalculatorService(IVehicleRentalPriceService vehicleRentalPriceService,
                                                   IRentVehicleService rentVehicleService)
        {
            VehicleRentalPriceService = vehicleRentalPriceService;
            RentVehicleService = rentVehicleService;
        }
        public Response<VehicleRentalPriceCalculationResultDTO> Calculate(RentVehicleDTO rentVehicle)
        {
            var validationResponse = Validate(rentVehicle);
            if (validationResponse.IsSuccess == false)
                return validationResponse;

            var checkVehicleAvailability = CheckVehicleAvailability(rentVehicle.VehicleId,
                                                                   rentVehicle.DeliveryDate.Value,
                                                                   rentVehicle.ReturnDate.Value);
            if (checkVehicleAvailability.IsSuccess == false)
                return checkVehicleAvailability;
 
            int days = rentVehicle.ReturnDate.Value.Subtract(rentVehicle.DeliveryDate.Value).Days;
            var prices = VehicleRentalPriceService.Get(new VehicleRentalPriceFilter(rentVehicle.VehicleId, rentVehicle.DeliveryDate.Value));
            if (days<30)
            {//Günlük
                return CalculateDaily(days, prices);
            }
            else if (days<180)
            {//Aylık
                return CalculateMontly(days, prices);
            }
            else
            {//6 Aylık
                return Calculate6Montly(days, prices);
            }

        }

        private Response<VehicleRentalPriceCalculationResultDTO> CalculateDaily(int days,List<VehicleRentalPriceDTO> prices)
        {
            var vehicleRentalPrice = prices.Where(p => p.RentalPeriodId == RentalPeriodConstants.Gunluk).SingleOrDefault();
            if (vehicleRentalPrice == null)
                return Response<VehicleRentalPriceCalculationResultDTO>.Fail("Kiralama tarifesi bulunamadı");

            decimal amount = vehicleRentalPrice.Price * days;
            return Response<VehicleRentalPriceCalculationResultDTO>.Success(data: new VehicleRentalPriceCalculationResultDTO
            {
                Amount = amount,
                NumberOfDays = days,
                VehicleRentalPriceId = vehicleRentalPrice.Id
            });
        }

        private Response<VehicleRentalPriceCalculationResultDTO> CalculateMontly(int days, List<VehicleRentalPriceDTO> prices)
        {
            var vehicleRentalPrice = prices.Where(p => p.RentalPeriodId == RentalPeriodConstants.Aylik).SingleOrDefault();
            if (vehicleRentalPrice == null)
                return CalculateDaily(days, prices);

            decimal amount = vehicleRentalPrice.Price * days;
            return Response<VehicleRentalPriceCalculationResultDTO>.Success(data: new VehicleRentalPriceCalculationResultDTO
            {
                Amount = amount,
                NumberOfDays = days,
                VehicleRentalPriceId = vehicleRentalPrice.Id
            });
        }

        private Response<VehicleRentalPriceCalculationResultDTO> Calculate6Montly(int days,List<VehicleRentalPriceDTO> prices)
        {
            var vehicleRentalPrice = prices.Where(p => p.RentalPeriodId == RentalPeriodConstants._6_Aylik).SingleOrDefault();
            if (vehicleRentalPrice==null)
                return CalculateMontly(days, prices);

            decimal amount = vehicleRentalPrice.Price * days;
            return Response<VehicleRentalPriceCalculationResultDTO>.Success(data: new VehicleRentalPriceCalculationResultDTO
            {
                Amount = amount,
                NumberOfDays=days,
                VehicleRentalPriceId=vehicleRentalPrice.Id
            });
        }

        private Response<VehicleRentalPriceCalculationResultDTO> Validate(RentVehicleDTO rentVehicle)
        {
            if (rentVehicle.DeliveryDate.HasValue == false || rentVehicle.ReturnDate.HasValue == false)
                return Response<VehicleRentalPriceCalculationResultDTO>.Fail("Lüften tarihleri kontrol ediniz");
            if (rentVehicle.DeliveryDate.Value > rentVehicle.ReturnDate.Value)
                return Response<VehicleRentalPriceCalculationResultDTO>.Fail("İade tarihini alış tarihinden ileri bir tarih olarak seçiniz");
            if (rentVehicle.DeliveryDate.Value.Date <= DateTime.Today)
                return Response<VehicleRentalPriceCalculationResultDTO>.Fail("Lüften alış tarihini en erken yarın olarak seçiniz");
            return Response<VehicleRentalPriceCalculationResultDTO>.Success();
        }
        private Response<VehicleRentalPriceCalculationResultDTO> CheckVehicleAvailability(int vehicleId,DateTime deliveryDate,DateTime returnDate)
        {
            var checkResponse = RentVehicleService.ChechVehicleAvailability(vehicleId, deliveryDate, returnDate);
            if (checkResponse.IsSuccess == false)
                return Response<VehicleRentalPriceCalculationResultDTO>.Fail(checkResponse.Message);

            return Response<VehicleRentalPriceCalculationResultDTO>.Success();
        }

    }

}
