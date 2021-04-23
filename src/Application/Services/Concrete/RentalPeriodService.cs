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
    public class RentalPeriodService : BaseService, IRentalPeriodService
    {
        public RentalPeriodService(ICarRentalDbContext context) : base(context)
        {

        }
        public Response Add(RentalPeriod rentalPeriod)
        {
            var chechResponse = ChechToAddOrUpdate(rentalPeriod);
            if (!chechResponse.IsSuccess)
                return chechResponse;

            Context.RentalPeriod.Add(rentalPeriod);
            Context.SaveChanges();
            return Response.Success("Kiralama süresi başarıyla kaydedildi");
        }
        private Response ChechToAddOrUpdate(RentalPeriod rentalPeriod)
        {
            int sameNumberOfRecords = (from r in Context.ColorType
                                       where r.Name == rentalPeriod.Name && r.Id != rentalPeriod.Id
                                       select r
                                          ).Count();
            if (sameNumberOfRecords > 0)
            {
                return Response.Fail($"{rentalPeriod.Name} kiralama süresi sistemde zaten kayıtlıdır.");
            }
            return Response.Success();

        }
        public Response Update(RentalPeriod rentalPeriod)
        {
            var checkResponse = ChechToAddOrUpdate(rentalPeriod);
            if (!checkResponse.IsSuccess)
                return checkResponse;
            var rentalPeriodToUpdate = GetById(rentalPeriod.Id);
            rentalPeriodToUpdate.Name = rentalPeriod.Name;
            Context.SaveChanges();
            return Response.Success("Kiralama süresi başarıyla güncellendi.");
        }

        public Response Delete(int id)
        {
            var rentalPeriodToDelete = GetById(id);
            Context.RentalPeriod.Remove(rentalPeriodToDelete);
            Context.SaveChanges();

            return Response.Success("Yakıt tipi başarıyla silindi.");
        }

        public List<RentalPeriod> Get(RentalPeriodFilter filter)
        {
            var items = (from v in Context.RentalPeriod
                         where v.Name.StartsWith(filter.Name)
                         orderby v.Name
                         select v).ToList();
            return items;
        }

        public RentalPeriod GetById(int id)
        {
            {
                return Context.RentalPeriod.Where(v => v.Id == id).SingleOrDefault();
            }


        }
    }
}
