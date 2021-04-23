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
    public class TireTypeService : BaseService, ITireTypeService
    {
        public TireTypeService(ICarRentalDbContext context) : base(context)
        {

        }
        public Response Add(TireType tireType)
        {
            var chechResponse = ChechToAddOrUpdate(tireType);
            if (!chechResponse.IsSuccess)
                return chechResponse;

            Context.TireType.Add(tireType);
            Context.SaveChanges();
            return Response.Success("Lastik tipi başarıyla kaydedildi");
        }
        private Response ChechToAddOrUpdate(TireType tireType)
        {
            int sameNumberOfRecords = (from t in Context.TireType
                                       where t.Name == tireType.Name && t.Id != tireType.Id
                                       select t
                                          ).Count();
            if (sameNumberOfRecords > 0)
            {
                return Response.Fail($"{tireType.Name} lastik tipi sistemde zaten kayıtlıdır.");
            }
            return Response.Success();

        }
        public Response Update(TireType tireType)
        {
            var checkResponse = ChechToAddOrUpdate(tireType);
            if (!checkResponse.IsSuccess)
                return checkResponse;
            var tireTypeToUpdate = GetById(tireType.Id);
            tireTypeToUpdate.Name = tireType.Name;
            Context.SaveChanges();
            return Response.Success("Lastik tipi başarıyla güncellendi.");
        }

        public Response Delete(int id)
        {
            var tireTypeToDelete = GetById(id);
            Context.TireType.Remove(tireTypeToDelete);
            Context.SaveChanges();

            return Response.Success("Lastik tipi başarıyla silindi.");
        }

        public List<TireType> Get(TireTypeFilter filter)
        {
            var items = (from v in Context.TireType
                         where v.Name.StartsWith(filter.Name)
                         orderby v.Name
                         select v).ToList();
            return items;
        }

        public TireType GetById(int id)
        {
            return Context.TireType.Where(v => v.Id == id).SingleOrDefault();
        }
    }
}
