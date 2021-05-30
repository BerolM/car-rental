using Application.Infrastructure.Persistence;
using Application.Services.Commons;
using Domain.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Concrete
{
    internal class RentVehicleService : BaseService, IRentVehicleService

    {
        public RentVehicleService(ICarRentalDbContext context) : base(context) { }
        public Response Add(RentVehicle rentVehicle)
        {
            var checkResponse = ChechVehicleAvailability(rentVehicle.VehicleId, rentVehicle.DeliveryDate, rentVehicle.ReturnDate);
            if (checkResponse.IsSuccess == false)
                return checkResponse;
            Context.RentVehicle.Add(rentVehicle);
            Context.SaveChanges();

            return Response.Success("Araç kiralma işleminiz tamamlanmıştır.İyi yolculuklar dileriz.");
        }

        public Response ChechVehicleAvailability(int vehicleId, DateTime deliveryDate, DateTime returnDate)
        {
            var numberOfRentalsInTheSameDateRange =
                (
                    from rv in Context.RentVehicle
                    where rv.VehicleId == vehicleId
                        &&
                        (
                            (rv.DeliveryDate <= deliveryDate && rv.ReturnDate >= deliveryDate)
                            ||
                            (rv.DeliveryDate >= deliveryDate && rv.ReturnDate <= returnDate)
                            ||
                            (rv.DeliveryDate <= returnDate && rv.ReturnDate >= returnDate)
                            ||
                            (rv.DeliveryDate <= deliveryDate && rv.ReturnDate >= returnDate)
                        )
                    select rv
                ).Count();
            if (numberOfRentalsInTheSameDateRange > 0)
                return Response.Fail("Seçtiğiniz tarih aralığında bu araç kiralanmıştır.Lüften başka bir tarih aralığı seçiniz.");

            return Response.Success();
        }
    }
}
