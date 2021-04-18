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
    public class VehicleModelService :BaseService , IVehicleModelService
    {
        public VehicleModelService(ICarRentalDbContext context) : base(context)
        {
        }
        public Response Add(VehicleModel vehicleModel)
        {
            Context.VehicleModel.Add(vehicleModel);
            Context.SaveChanges();
            return Response.Success("Model başarıyla kaydedildi");
        }

        public Response Delete(int id)
        {
            var vehicleModelToDelete = GetById(id);
            Context.VehicleModel.Remove(vehicleModelToDelete);
            Context.SaveChanges();

            return Response.Success("Model başarıyla silindi");
        }

        public List<VehicleModel> Get(VehicleModelFilter filter)
        {
            var items = (from m in Context.VehicleModel
                         orderby m.Name
                         select m).ToList();
            return items;
        }

        public VehicleModel GetById(int id)
        {
            return Context.VehicleModel.Where(m => m.Id == id).SingleOrDefault();
        }

        public Response Update(VehicleModel vehicleModel)
        {
            var vehicleModelToUpdate = GetById(vehicleModel.Id);
            vehicleModelToUpdate.Name = vehicleModel.Name;
            vehicleModelToUpdate.VehicleBrandId = vehicleModel.VehicleBrandId;
            Context.SaveChanges();

            return Response.Success("Model başarıyla güncellendi");
        }
    }
}
