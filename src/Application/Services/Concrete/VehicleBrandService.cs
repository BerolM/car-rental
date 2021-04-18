using Application.Infrastructure.Persistence;
using Application.Services.Commons;
using Domain.DTOs;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services.Concrete
{
    public class VehicleBrandService : BaseService, IVehicleBrandService
    {

        public VehicleBrandService(ICarRentalDbContext context) : base(context)
        {

        }
        public Response Add(VehicleBrand vehicleBrand)
        {
            var checkResponse = ChechToAddOrUpdate(vehicleBrand);
            if (!checkResponse.IsSuccess)
                return checkResponse;

            Context.VehicleBrand.Add(vehicleBrand);
            Context.SaveChanges();

            return Response.Success("Marka başarıyla kaydedildi.");

        }
        private Response ChechToAddOrUpdate(VehicleBrand vehicleBrand)
        {
            int sameNumberOfRecords = (from b in Context.VehicleBrand
                                       where b.Name == vehicleBrand.Name && b.Id != vehicleBrand.Id
                                       select b
                                          ).Count();
            if (sameNumberOfRecords > 0)
            {
                return Response.Fail($"{vehicleBrand.Name} markası sistemde zaten kayıtlıdır.");
            }
            return Response.Success();

        }
        public Response Update(VehicleBrand vehicleBrand)
        {
            var checkResponse = ChechToAddOrUpdate(vehicleBrand);
            if (!checkResponse.IsSuccess)
                return checkResponse;
            var vehicleBrandToUpdate = GetById(vehicleBrand.Id);
            vehicleBrandToUpdate.Name = vehicleBrand.Name;
            Context.SaveChanges();
            return Response.Success("Marka başarıyla güncellendi.");
        }
        public Response Delete(int id)
        {
            var vehicleBrandToDelete = GetById(id);
            Context.VehicleBrand.Remove(vehicleBrandToDelete);
            Context.SaveChanges();

            return Response.Success("Marka başarıyla silindi.");
        }
        public VehicleBrand GetById(int id)
        {
            return Context.VehicleBrand.Where(v => v.Id == id).SingleOrDefault();
        }
        public List<VehicleBrand> Get(VehicleBrandFilter filter)
        {
            var items = (from v in Context.VehicleBrand
                         where v.Name.StartsWith(filter.Name)
                         orderby v.Name
                         select v).ToList();
            return items;
        }
        public string GetName()
        {
            return "Vehicle brand service";
        }
    }

}
