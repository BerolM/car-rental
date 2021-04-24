using Application.Infrastructure.Persistence;
using Application.Services.Commons;
using Domain.DTOs;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services.Concrete
{
    public class VehicleModelService : BaseService, IVehicleModelService
    {
        public VehicleModelService(ICarRentalDbContext context) : base(context)
        {
        }
        public Response Add(VehicleModel vehicleModel)
        {
            var checkResponse = ChechToAddOrUpdate(vehicleModel);
            if (!checkResponse.IsSuccess)
                return checkResponse;

            Context.VehicleModel.Add(vehicleModel);
            Context.SaveChanges();
            return Response.Success("Model başarıyla kaydedildi");
        }

        public Response Update(VehicleModel vehicleModel)
        {
            var checkResponse = ChechToAddOrUpdate(vehicleModel);
            if (!checkResponse.IsSuccess)
                return checkResponse;

            var vehicleModelToUpdate = GetById(vehicleModel.Id);
            vehicleModelToUpdate.Name = vehicleModel.Name;
            vehicleModelToUpdate.VehicleBrandId = vehicleModel.VehicleBrandId;
            Context.SaveChanges();

            return Response.Success("Model başarıyla güncellendi");
        }

        public Response Delete(int id)
        {
            var vehicleModelToDelete = GetById(id);
            Context.VehicleModel.Remove(vehicleModelToDelete);
            Context.SaveChanges();

            return Response.Success("Model başarıyla silindi");
        }

        public List<VehicleModelDTO> Get(VehicleModelFilter filter)
        {
            var items = (from m in Context.VehicleModel
                         join b in Context.VehicleBrand on m.VehicleBrandId equals b.Id
                         orderby m.Name
                         select new VehicleModelDTO 
                         { 
                             Id=m.Id,
                             Name=m.Name,
                             VehicleBrandId=m.VehicleBrandId,
                             VehicleBrandName=b.Name
                         }).ToList();
            return items;
        }

        public VehicleModel GetById(int id)
        {
            return Context.VehicleModel.Where(m => m.Id == id).SingleOrDefault();
        }
        public VehicleModelDTO GetDetail(int id)
        {
            var item = (from m in Context.VehicleModel.Include(m=>m.VehicleBrand)
                        where m.Id == id
                        select new VehicleModelDTO
                        {
                            Id = m.Id,
                            Name = m.Name,
                            VehicleBrandId = m.VehicleBrandId,
                            VehicleBrandName = m.VehicleBrand.Name
                        }).SingleOrDefault();
            return item;
        }

        private Response ChechToAddOrUpdate(VehicleModel vehicleModel)
        {
            int sameNumberOfRecords = (from m in Context.VehicleModel
                                       where m.Name == vehicleModel.Name &&
                                             m.VehicleBrandId==vehicleModel.VehicleBrandId &&
                                             m.Id != vehicleModel.Id
                                       select m
                                     ).Count();
            if (sameNumberOfRecords>0)
            {
                return Response.Fail($"{vehicleModel.Name} modeli sistemde zaten kayıtlıdır.");
            }
            return Response.Success();
        }
    }
}
