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
    public class VehicleClassTypeService : BaseService, IVehicleClassTypeService
    {
        public VehicleClassTypeService(ICarRentalDbContext context) : base(context)
        {

        }
        public Response Add(VehicleClassType vehicleClassType)
        {
            var checkResponse = ChechToAddOrUpdate(vehicleClassType);
            if (!checkResponse.IsSuccess)
                return checkResponse;

            Context.VehicleClassType.Add(vehicleClassType);
            Context.SaveChanges();

            return Response.Success("Araç sınıfı başarıyla kaydedildi.");
        }
        private Response ChechToAddOrUpdate(VehicleClassType vehicleClassType)
        {
            int sameNumberOfRecords = (from v in Context.VehicleClassType
                                       where v.Name == vehicleClassType.Name && v.Id != vehicleClassType.Id
                                       select v
                                          ).Count();
            if (sameNumberOfRecords > 0)
            {
                return Response.Fail($"{vehicleClassType.Name} sınıfı sistemde zaten kayıtlıdır.");
            }
            else
               return Response.Success();

        }
        public Response Update(VehicleClassType vehicleClassType)
        {
            var checkResponse = ChechToAddOrUpdate(vehicleClassType);
            if (!checkResponse.IsSuccess)
                return checkResponse;
            var vehicleClassTypeToUpdate = GetById(vehicleClassType.Id);
            vehicleClassTypeToUpdate.Name = vehicleClassType.Name;
            vehicleClassTypeToUpdate.Description = vehicleClassType.Description;
            Context.SaveChanges();
            return Response.Success("Araç sınıfı başarıyla güncellendi.");
        }

        public Response Delete(int id)
        {
            var vehicleClassTypeToDelete = GetById(id);
            Context.VehicleClassType.Remove(vehicleClassTypeToDelete);
            Context.SaveChanges();

            return Response.Success("Araç sınıfı başarıyla silindi.");
        }

        public List<VehicleClassType> Get(VehicleClassTypeFilter filter)
        {
            var items = (from v in Context.VehicleClassType
                         where v.Name.StartsWith(filter.Name)
                         orderby v.Name
                         select v).ToList();
            return items;
        }

        public VehicleClassType GetById(int id)
        {
            {
                return Context.VehicleClassType.Where(v => v.Id == id).SingleOrDefault();
            }
        }

       
    }
}
