using Application.Services.Commons;
using Application.Infrastructure.Persistence;
using Domain.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.Services.Concrete
{
    public class FuelTypeService : BaseService, IFuelTypeService
    {
        public FuelTypeService(ICarRentalDbContext context) : base(context)
        {

        }
        public Response Add(FuelType fuelType)
        {
            var chechResponse = ChechToAddOrUpdate(fuelType);
            if (!chechResponse.IsSuccess)
                return chechResponse;

            Context.FuelType.Add(fuelType);
            Context.SaveChanges();
            return Response.Success("Yakıt tipi başarıyla kaydedildi");
        }
        private Response ChechToAddOrUpdate(FuelType fuelType)
        {
            int sameNumberOfRecords = (from f in Context.ColorType
                                       where f.Name == fuelType.Name && f.Id != fuelType.Id
                                       select f
                                          ).Count();
            if (sameNumberOfRecords > 0)
            {
                return Response.Fail($"{fuelType.Name} yakıt tipi sistemde zaten kayıtlıdır.");
            }
            return Response.Success();

        }
        public Response Update(FuelType fuelType)
        {
            var checkResponse = ChechToAddOrUpdate(fuelType);
            if (!checkResponse.IsSuccess)
                return checkResponse;
            var fuelTypeToUpdate = GetById(fuelType.Id);
            fuelTypeToUpdate.Name = fuelType.Name;
            Context.SaveChanges();
            return Response.Success("Yakıt tipi başarıyla güncellendi.");
        }

        public Response Delete(int id)
        {
            var fuelTypeToDelete = GetById(id);
            Context.FuelType.Remove(fuelTypeToDelete);
            Context.SaveChanges();

            return Response.Success("Yakıt tipi başarıyla silindi.");
        }

        public List<FuelType> Get(FuelTypeFilter filter)
        {
            var items = (from v in Context.FuelType
                         where v.Name.StartsWith(filter.Name)
                         orderby v.Name
                         select v).ToList();
            return items;
        }

        public FuelType GetById(int id)
        {
            return Context.FuelType.Where(v => v.Id == id).SingleOrDefault();
        }

    }
}
