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
    public class TransmissionTypeService : BaseService, ITransmissionTypeService
    {
        public TransmissionTypeService(ICarRentalDbContext context) : base(context)
        {

        }
        public Response Add(TransmissionType transmissionType)
        {
            var chechResponse = ChechToAddOrUpdate(transmissionType);
            if (!chechResponse.IsSuccess)
                return chechResponse;

            Context.TransmissionType.Add(transmissionType);
            Context.SaveChanges();
            return Response.Success("Vites tipi başarıyla kaydedildi");
        }
        private Response ChechToAddOrUpdate(TransmissionType transmissionType)
        {
            int sameNumberOfRecords = (from t in Context.TransmissionType
                                       where t.Name == transmissionType.Name && t.Id != transmissionType.Id
                                       select t
                                          ).Count();
            if (sameNumberOfRecords > 0)
            {
                return Response.Fail($"{transmissionType.Name} vites tipi sistemde zaten kayıtlıdır.");
            }
            return Response.Success();

        }
            public Response Update(TransmissionType transmissionType)
        {
            var checkResponse = ChechToAddOrUpdate(transmissionType);
            if (!checkResponse.IsSuccess)
                return checkResponse;
            var transmissionTypeToUpdate = GetById(transmissionType.Id);
            transmissionTypeToUpdate.Name = transmissionType.Name;
            Context.SaveChanges();
            return Response.Success("Vites tipi başarıyla güncellendi.");
        }
        public Response Delete(int id)
        {
            var transmissionTypeToDelete = GetById(id);
            Context.TransmissionType.Remove(transmissionTypeToDelete);
            Context.SaveChanges();

            return Response.Success("Vites tipi başarıyla silindi.");
        }

        public List<TransmissionType> Get(TransmissionTypeFilter filter)
        {
            var items = (from v in Context.TransmissionType
                         where v.Name.StartsWith(filter.Name)
                         orderby v.Name
                         select v).ToList();
            return items;
        }

        public TransmissionType GetById(int id)
        {
            return Context.TransmissionType.Where(v => v.Id == id).SingleOrDefault();
        }


    }
}
