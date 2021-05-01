using Application.Services.Commons;
using Domain.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;


namespace Application.Services.Concrete
{
    public class VehicleRentalPriceService : BaseService, IVehicleRentalPriceService
    {
        public VehicleRentalPriceService(ICarRentalDbContext context) : base(context)
        {

        }

        public Response Add(VehicleRentalPrice vehicleRentalPrice)
        {
            var checkReponse = CheckToAddOrUpdate(vehicleRentalPrice);
            if (!checkReponse.IsSuccess)
                return checkReponse;

            Context.VehicleRentalPrice.Add(vehicleRentalPrice);
            Context.SaveChanges();

            return Response.Success("Kiralama tarifesi başarıyla kaydedildi");
        }
        public Response Update(VehicleRentalPrice vehicleRentalPrice)
        {
            var checkReponse = CheckToAddOrUpdate(vehicleRentalPrice);
            if (!checkReponse.IsSuccess)
                return checkReponse;

            var vehicleRentalPriceToUpdate = GetById(vehicleRentalPrice.Id);
            vehicleRentalPriceToUpdate.StartDate = vehicleRentalPrice.StartDate;
            vehicleRentalPriceToUpdate.EndDate = vehicleRentalPrice.EndDate;
            vehicleRentalPriceToUpdate.Price = vehicleRentalPrice.Price;
            vehicleRentalPriceToUpdate.RentalPeriodId = vehicleRentalPrice.RentalPeriodId;
            Context.SaveChanges();

            return Response.Success("Kiralama tarifesi başarıyla güncellendi");
        }
        private Response CheckToAddOrUpdate(VehicleRentalPrice vehicleRentalPrice)
        {
            if (vehicleRentalPrice.StartDate > vehicleRentalPrice.EndDate)
                return Response.Fail("Bitiş tarihi başlangıç tarihinden ileri bir tarih olmamalıdır");

            int numberOfRecordsInTheSameDateRange =
                                (from p in Context.VehicleRentalPrice
                                 where p.VehicleId == vehicleRentalPrice.VehicleId && p.Id != vehicleRentalPrice.Id
                                    &&
                                    (
                                        (p.StartDate <= vehicleRentalPrice.StartDate && p.EndDate >= vehicleRentalPrice.StartDate)
                                        ||
                                        (p.StartDate >= vehicleRentalPrice.StartDate && p.EndDate <= vehicleRentalPrice.EndDate)
                                        ||
                                        (p.StartDate <= vehicleRentalPrice.EndDate && p.EndDate >= vehicleRentalPrice.EndDate)
                                        ||
                                        (p.StartDate <= vehicleRentalPrice.StartDate && p.EndDate >= vehicleRentalPrice.EndDate)
                                    )
                                 select p
                                ).Count();
            if (numberOfRecordsInTheSameDateRange > 0)
                return Response.Fail("Bu tarih aralığında kayıtlı başka bir tarife vardır");

            return Response.Success();
        }

        public Response Delete(int id)
        {
            var vehicleRentalPriceToDelete = GetById(id);
            Context.VehicleRentalPrice.Remove(vehicleRentalPriceToDelete);
            Context.SaveChanges();

            return Response.Success("Kiralama tarifesi başarıyla silindi");
        }

        public VehicleRentalPrice GetById(int id)
        {
            return Context.VehicleRentalPrice.Where(p => p.Id == id).SingleOrDefault();
        }

        public List<VehicleRentalPriceDTO> Get(VehicleRentalPriceFilter filter)
        {
            var items = (from p in Context.VehicleRentalPrice.Include(x => x.Vehicle.VehicleModel.VehicleBrand)
                                                             .Include(x => x.RentalPeriod)
                         where p.VehicleId == filter.VehicleId
                         orderby p.StartDate descending
                         select new VehicleRentalPriceDTO
                         {
                             Id = p.Id,
                             StartDate = p.StartDate,
                             EndDate = p.EndDate,
                             Price = p.Price,
                             RentalPeriodId = p.RentalPeriodId,
                             RentalPeriodName = p.RentalPeriod.Name,
                             VehicleId = p.VehicleId,
                             VehicleModelName = p.Vehicle.VehicleModel.Name,
                             VehicleBrandName = p.Vehicle.VehicleModel.VehicleBrand.Name
                         }).ToList();
            return items;
        }


        public VehicleRentalPriceDTO GetDetail(int id)
        {
            var item = (from p in Context.VehicleRentalPrice.Include(x => x.Vehicle.VehicleModel.VehicleBrand)
                                                             .Include(x => x.RentalPeriod)
                        where p.Id == id
                        select new VehicleRentalPriceDTO
                        {
                            Id = p.Id,
                            StartDate = p.StartDate,
                            EndDate = p.EndDate,
                            Price = p.Price,
                            RentalPeriodId = p.RentalPeriodId,
                            RentalPeriodName = p.RentalPeriod.Name,
                            VehicleId = p.VehicleId,
                            VehicleModelName = p.Vehicle.VehicleModel.Name,
                            VehicleBrandName = p.Vehicle.VehicleModel.VehicleBrand.Name
                        }).SingleOrDefault();
            return item;
        }

    }
}